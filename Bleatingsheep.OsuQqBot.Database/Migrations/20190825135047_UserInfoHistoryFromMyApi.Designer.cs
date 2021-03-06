﻿// <auto-generated />
using System;
using Bleatingsheep.OsuQqBot.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bleatingsheep.OsuQqBot.Database.Migrations
{
    [DbContext(typeof(NewbieContext))]
    [Migration("20190825135047_UserInfoHistoryFromMyApi")]
    partial class UserInfoHistoryFromMyApi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bleatingsheep.Osu.PerformancePlus.BeatmapPlus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<float>("Accuracy");

                    b.Property<float>("AimFlow");

                    b.Property<float>("AimJump");

                    b.Property<float>("AimTotal");

                    b.Property<float>("Precision");

                    b.Property<float>("Speed");

                    b.Property<float>("Stamina");

                    b.Property<float>("Stars");

                    b.HasKey("Id");

                    b.ToTable("BeatmapPlusCache");
                });

            modelBuilder.Entity("Bleatingsheep.OsuMixedApi.Beatmap", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Mode");

                    b.Property<double>("AR");

                    b.Property<int>("Approved");

                    b.Property<DateTimeOffset?>("ApprovedDateOffset");

                    b.Property<string>("Artist")
                        .IsRequired();

                    b.Property<double>("Bpm");

                    b.Property<double>("CS");

                    b.Property<string>("Creator")
                        .IsRequired();

                    b.Property<string>("DifficultyName")
                        .IsRequired();

                    b.Property<int>("FavoriteCount");

                    b.Property<string>("FileMD5")
                        .IsRequired();

                    b.Property<int>("Genre");

                    b.Property<double>("HP");

                    b.Property<int>("HitLength");

                    b.Property<int>("Language");

                    b.Property<DateTimeOffset>("LastUpdateOffset");

                    b.Property<int?>("MaxCombo");

                    b.Property<double>("OD");

                    b.Property<int>("SetId");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.Property<double>("Stars");

                    b.Property<string>("Tags")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TotalLength");

                    b.HasKey("Id", "Mode");

                    b.HasIndex("FileMD5")
                        .HasName("index_md5");

                    b.ToTable("CachedBeatmaps");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.BindingInfo", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<int>("OsuId")
                        .IsConcurrencyToken();

                    b.Property<string>("Source")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Bindings");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.Chart", b =>
                {
                    b.Property<int>("ChartId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ChartCreator");

                    b.Property<string>("ChartDescription")
                        .IsRequired();

                    b.Property<string>("ChartName")
                        .IsRequired();

                    b.Property<DateTimeOffset?>("EndTime");

                    b.Property<bool>("IsRunning");

                    b.Property<double?>("MaximumPerformance");

                    b.Property<bool>("Public");

                    b.Property<double>("RecommendPerformance");

                    b.Property<DateTimeOffset>("StartTime");

                    b.HasKey("ChartId");

                    b.ToTable("Charts");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartAdministrator", b =>
                {
                    b.Property<int>("ChartId");

                    b.Property<long>("Administrator");

                    b.HasKey("ChartId", "Administrator");

                    b.ToTable("ChartAdministrators");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartBeatmap", b =>
                {
                    b.Property<int>("ChartId");

                    b.Property<int>("BeatmapId");

                    b.Property<int>("Mode");

                    b.Property<bool>("AllowsFail");

                    b.Property<int>("BannedMods");

                    b.Property<int>("ForceMods");

                    b.Property<int>("RequiredMods");

                    b.Property<string>("ScoreCalculation");

                    b.HasKey("ChartId", "BeatmapId", "Mode");

                    b.ToTable("ChartBeatmaps");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartTry", b =>
                {
                    b.Property<int>("ChartId");

                    b.Property<int>("BeatmapId");

                    b.Property<int>("Mode");

                    b.Property<long>("Date");

                    b.Property<int>("UserId");

                    b.Property<double>("Accuracy");

                    b.Property<int>("Combo");

                    b.Property<int>("Mods");

                    b.Property<double>("PPWhenCommit");

                    b.Property<string>("Rank")
                        .IsRequired();

                    b.Property<long>("Score");

                    b.HasKey("ChartId", "BeatmapId", "Mode", "Date", "UserId");

                    b.ToTable("ChartTries");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartValidGroup", b =>
                {
                    b.Property<int>("ChartId");

                    b.Property<long>("GroupId");

                    b.HasKey("ChartId", "GroupId");

                    b.ToTable("ChartValidGroups");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.GroupMemberInfo", b =>
                {
                    b.Property<string>("GroupName");

                    b.Property<long>("UserId");

                    b.HasKey("GroupName", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupMemberInfo");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.MemberGroup", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.MemberInfo", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<bool>("HadBeenWelcome");

                    b.HasKey("UserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.OperationHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Operation");

                    b.Property<string>("Operator");

                    b.Property<long?>("OperatorId");

                    b.Property<string>("Remark")
                        .IsRequired();

                    b.Property<string>("User");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.PlusHistory", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<int>("Accuracy");

                    b.Property<int>("AimFlow");

                    b.Property<int>("AimJump");

                    b.Property<int>("AimTotal");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Performance");

                    b.Property<int>("Precision");

                    b.Property<int>("Speed");

                    b.Property<int>("Stamina");

                    b.HasKey("Id", "Date");

                    b.ToTable("PlusHistories");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.RelationshipInfo", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("Relationship");

                    b.Property<int>("Target")
                        .IsConcurrencyToken();

                    b.HasKey("UserId", "Relationship");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.UserHistoryInfo", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTimeOffset>("Date");

                    b.Property<int>("Mode");

                    b.Property<double>("AccuracyPercent");

                    b.Property<int>("Count100");

                    b.Property<int>("Count300");

                    b.Property<int>("Count50");

                    b.Property<int>("CountRankA");

                    b.Property<int>("CountRankS");

                    b.Property<int>("CountRankSH");

                    b.Property<int>("CountRankSS");

                    b.Property<int>("CountRankSSH");

                    b.Property<string>("CountryCode")
                        .IsRequired();

                    b.Property<int>("CountryRank");

                    b.Property<DateTime>("JoinDate");

                    b.Property<double>("Level");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Performance");

                    b.Property<int>("PlayCount");

                    b.Property<int>("Rank");

                    b.Property<long>("RankedScore");

                    b.Property<long>("TotalScore");

                    b.Property<int>("TotalSecondsPlayed");

                    b.HasKey("Id", "Date", "Mode");

                    b.ToTable("UserHistories");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.WebLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IPAddress")
                        .IsRequired();

                    b.Property<string>("Kind")
                        .IsRequired();

                    b.Property<string>("Location");

                    b.Property<DateTimeOffset>("Time");

                    b.Property<string>("Token");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("WebLogs");
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartAdministrator", b =>
                {
                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.Chart")
                        .WithMany("Administrators")
                        .HasForeignKey("ChartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartBeatmap", b =>
                {
                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.Chart", "Chart")
                        .WithMany("Maps")
                        .HasForeignKey("ChartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartTry", b =>
                {
                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.Chart", "Chart")
                        .WithMany()
                        .HasForeignKey("ChartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.ChartBeatmap", "Beatmap")
                        .WithMany("Commits")
                        .HasForeignKey("ChartId", "BeatmapId", "Mode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.ChartValidGroup", b =>
                {
                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.Chart")
                        .WithMany("Groups")
                        .HasForeignKey("ChartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bleatingsheep.OsuQqBot.Database.Models.GroupMemberInfo", b =>
                {
                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.MemberGroup", "Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupName")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bleatingsheep.OsuQqBot.Database.Models.MemberInfo", "Member")
                        .WithMany("Groups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
