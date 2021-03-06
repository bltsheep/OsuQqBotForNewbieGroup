﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bleatingsheep.NewHydrant.Attributions;
using Bleatingsheep.NewHydrant.Core;
using Sisters.WudiLib;
using Sisters.WudiLib.Posts;
using WebApiClient;
using Message = Sisters.WudiLib.SendingMessage;
using MessageContext = Sisters.WudiLib.Posts.Message;

namespace Bleatingsheep.NewHydrant.啥玩意儿啊.Exchange
{
    [Component("ex_rates")]
    public class ExchangeRates : Service, IMessageCommand
    {
        static ExchangeRates()
        {
            HttpApi.Register<IExchangeRate>();
            HttpApi.Register<ICmbcCreditRate>();
            HttpApi.Register<ICibRate>();
        }

        private static readonly Regex s_regex = new Regex(@"^\s*汇率\s*([A-Za-z]{3})\s*(\d*\.?\d*)\s*$", RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex s_regex2 = new Regex(@"^\s*汇率\s*(\d*\.?\d*)\s*([A-Za-z]{3})\s*$", RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly IReadOnlyList<string> s_currencies = new List<string>
        {
            "CNY",
            "JPY",
            "USD",
        }.AsReadOnly();

        private string _text;

        public async Task ProcessAsync(MessageContext context, HttpApiClient api)
        {
            string @base;
            string amountString;

            if (s_regex.Match(_text) is { Success: true } match)
            {
                @base = match.Groups[1].Value;
                amountString = match.Groups[2].Value;
            }
            else if (s_regex2.Match(_text) is { Success: true } match2)
            {
                @base = match2.Groups[2].Value;
                amountString = match2.Groups[1].Value;
            }
            else
            {
                return;
            }

            if (!decimal.TryParse(amountString, out decimal amount))
            {
                await api.SendMessageAsync(context.Endpoint, "数字格式错误。").ConfigureAwait(false);
                return;
            }

            using var exRateApi = HttpApi.Resolve<IExchangeRate>();
            try
            {
                checked
                {
                    // cmbc
                    var cmbcTask = HttpApi.Resolve<ICmbcCreditRate>().GetRates();

                    // cib
                    var cibTask = HttpApi.Resolve<ICibRate>().GetRates();

                    var response = await exRateApi.GetExchangeRates(@base).ConfigureAwait(false);
                    var results = new List<string>(3);
                    foreach (var currency in s_currencies)
                    {
                        if (string.Equals(currency, @base, StringComparison.InvariantCultureIgnoreCase))
                        {
                            continue;
                        }
                        var rate = response.Rates[currency];
                        results.Add($"{currency} {amount * rate}");
                    }

                    //cmbc
                    try
                    {
                        var cmbcResult = await cmbcTask.ConfigureAwait(false);
                        var price = cmbcResult?.Data?.FirstOrDefault(d => string.Equals(@base, d?.Remark, StringComparison.OrdinalIgnoreCase))?.Price;
                        if (price != null)
                        {
                            var cny = amount * price.Value;
                            results.Add($"CMBC CNY {cny}");
                        }
                    }
                    catch (Exception e)
                    {
                        results.Add("CMBC 查询失败。");
                        Logger.Error(e);
                    }

                    // cib
                    try
                    {
                        var cibResult = await cibTask.ConfigureAwait(false);

                        var price = cibResult[@base];
                        if (price != null)
                        {
                            var cny = amount * price.Value;
                            results.Add($"CIB CNY {cny}");
                        }
                    }
                    catch (Exception e)
                    {
                        results.Add("CIB 查询失败。");
                        Logger.Error(e);
                    }

                    await api.SendMessageAsync(context.Endpoint, string.Join("\r\n", results)).ConfigureAwait(false);
                }
            }
            catch (OverflowException)
            {
                await api.SendMessageAsync(context.Endpoint, "数值过大或过小").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                await api.SendMessageAsync(context.Endpoint, "查询汇率失败。").ConfigureAwait(false);
                Logger.Error(e);
            }
        }

        public bool ShouldResponse(MessageContext context)
        {
            return context.Content.TryGetPlainText(out _text)
                && _text.TrimStart().StartsWith("汇率", StringComparison.InvariantCulture);
        }
    }
}
