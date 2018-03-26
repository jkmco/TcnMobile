﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TCN.Persistence;

namespace TCN.Migrations
{
    [DbContext(typeof(TcnDbContext))]
    [Migration("20180319045912_ChangeTransactionToTrade")]
    partial class ChangeTransactionToTrade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TCN.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TradeId");

                    b.HasKey("Id");

                    b.HasIndex("TradeId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("TCN.Models.Trade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastUpdatedAt");

                    b.Property<int>("MaxLimit");

                    b.Property<int>("MinLimit");

                    b.Property<int>("Price");

                    b.Property<int>("TradeCoinId");

                    b.Property<int>("TradeFxId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("TradeCoinId");

                    b.HasIndex("TradeFxId");

                    b.HasIndex("UserId");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("TCN.Models.TradeCoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TradeCoins");
                });

            modelBuilder.Entity("TCN.Models.TradeFx", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.ToTable("TradeFxs");
                });

            modelBuilder.Entity("TCN.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TCN.Models.Photo", b =>
                {
                    b.HasOne("TCN.Models.Trade", "Trade")
                        .WithMany("Photos")
                        .HasForeignKey("TradeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TCN.Models.Trade", b =>
                {
                    b.HasOne("TCN.Models.TradeCoin", "Coin")
                        .WithMany()
                        .HasForeignKey("TradeCoinId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCN.Models.TradeFx", "Fx")
                        .WithMany()
                        .HasForeignKey("TradeFxId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TCN.Models.User", "User")
                        .WithMany("Trades")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
