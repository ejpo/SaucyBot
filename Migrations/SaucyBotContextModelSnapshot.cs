﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaucyBot.Data;

namespace SaucyBot.Migrations
{
    [DbContext(typeof(SaucyBotContext))]
    partial class SaucyBotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SaucyBot.Model.Shared.SaucyUserEntity", b =>
                {
                    b.Property<ulong>("SaucyUserEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("DiscordID")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("GuildID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SaucyUserEntityID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SaucyBot.Model.Ticketing.TeamEntity", b =>
                {
                    b.Property<ulong>("TeamEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TeamEntityDiscordID")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TeamEntityGuildID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TeamEntityName")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamEntityID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SaucyBot.Model.Ticketing.TicketEntity", b =>
                {
                    b.Property<ulong>("TicketEntityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TeamEntityID")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("TicketEntityChannelID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TicketEntityCloseTime")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("TicketEntityLabelID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TicketEntityOpenTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("TicketEntityState")
                        .HasColumnType("INTEGER");

                    b.HasKey("TicketEntityID");

                    b.ToTable("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}