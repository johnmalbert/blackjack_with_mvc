﻿// <auto-generated />
using System;
using Cards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cards.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210507200400_newMigrations")]
    partial class newMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Cards.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeckId")
                        .HasColumnType("int");

                    b.Property<string>("Face")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImgURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Suit")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("DeckId");

                    b.ToTable("CardsInDeck");
                });

            modelBuilder.Entity("Cards.Models.CardInHand", b =>
                {
                    b.Property<int>("CardInHandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Face")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImgURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<bool>("Shown")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Suit")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("CardInHandId");

                    b.HasIndex("PlayerId");

                    b.ToTable("CardInHand");
                });

            modelBuilder.Entity("Cards.Models.Deck", b =>
                {
                    b.Property<int>("DeckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("DeckId");

                    b.ToTable("Decks");
                });

            modelBuilder.Entity("Cards.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Cards.Models.Card", b =>
                {
                    b.HasOne("Cards.Models.Deck", null)
                        .WithMany("CardsInDeck")
                        .HasForeignKey("DeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cards.Models.CardInHand", b =>
                {
                    b.HasOne("Cards.Models.Player", null)
                        .WithMany("CardsInHand")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}