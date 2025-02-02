﻿// <auto-generated />
using System;
using FernwehApi.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FernwehApi.Database.Migrations
{
    [DbContext(typeof(FernwehDbContext))]
    [Migration("20240919184842_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("FernwehApi.Database.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("FriendId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FriendUserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FriendUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlaceItemReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PlaceReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PlaceItemReviewId");

                    b.HasIndex("PlaceReviewId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("NodeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NodeId")
                        .IsUnique();

                    b.ToTable("Places");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceItems");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItemReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlaceItemId");

                    b.ToTable("PlaceItemReviews");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlaceReviews");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.Friend", b =>
                {
                    b.HasOne("FernwehApi.Database.Models.User", "FriendUser")
                        .WithMany()
                        .HasForeignKey("FriendUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FernwehApi.Database.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.Photo", b =>
                {
                    b.HasOne("FernwehApi.Database.Models.PlaceItemReview", null)
                        .WithMany("Photos")
                        .HasForeignKey("PlaceItemReviewId");

                    b.HasOne("FernwehApi.Database.Models.PlaceReview", null)
                        .WithMany("Photos")
                        .HasForeignKey("PlaceReviewId");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItem", b =>
                {
                    b.HasOne("FernwehApi.Database.Models.Place", "Place")
                        .WithMany("PlaceItems")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItemReview", b =>
                {
                    b.HasOne("FernwehApi.Database.Models.PlaceItem", "PlaceItem")
                        .WithMany("PlaceItemReviews")
                        .HasForeignKey("PlaceItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceItem");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceReview", b =>
                {
                    b.HasOne("FernwehApi.Database.Models.Place", "Place")
                        .WithMany("PlaceReviews")
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.Place", b =>
                {
                    b.Navigation("PlaceItems");

                    b.Navigation("PlaceReviews");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItem", b =>
                {
                    b.Navigation("PlaceItemReviews");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceItemReview", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("FernwehApi.Database.Models.PlaceReview", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
