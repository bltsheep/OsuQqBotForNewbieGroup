﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bleatingsheep.NewHydrant.Attributions;
using Sisters.WudiLib;
using Message = Sisters.WudiLib.SendingMessage;
using MessageContext = Sisters.WudiLib.Posts.Message;

namespace Bleatingsheep.NewHydrant.啥玩意儿啊
{
#nullable enable
    [Component("帮助")]
    public class 帮助 : IMessageCommand
    {
        public async Task ProcessAsync(MessageContext context, HttpApiClient api)
        {
            await api.SendMessageAsync(
                context.Endpoint,
                "请去 https://help.b11p.com/" +
                " 查看 osu! 相关帮助。页面右侧可以查看其他相关帮助。"
            ).ConfigureAwait(false);
        }

        public bool ShouldResponse(MessageContext context)
            => context.Content.TryGetPlainText(out var text)
            && text == "帮助";
    }
#nullable restore
}
