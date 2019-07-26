﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using flashcards.Data;

namespace flashcards.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("flashcards.Models.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Answer");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatorId");

                    b.Property<string>("Question");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("CardId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("flashcards.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatorId");

                    b.Property<string>("Name");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("flashcards.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("flashcards.Models.Card", b =>
                {
                    b.HasOne("flashcards.Models.Category", "Category")
                        .WithMany("Cards")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("flashcards.Models.User", "Creator")
                        .WithMany("MyCards")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("flashcards.Models.Category", b =>
                {
                    b.HasOne("flashcards.Models.User", "Creator")
                        .WithMany("MyCategories")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
