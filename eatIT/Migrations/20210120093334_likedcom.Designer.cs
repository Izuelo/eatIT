﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eatIT.Database;

namespace eatIT.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210120093334_likedcom")]
    partial class likedcom
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("eatIT.Database.Entity.CityEntity", b =>
                {
                    b.Property<int>("CityEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("text");

                    b.HasKey("CityEntityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CommentEntity", b =>
                {
                    b.Property<int>("CommentEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("CommentContent")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("NegativeScore")
                        .HasColumnType("integer");

                    b.Property<int>("PositiveScore")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("CommentEntityId", "UserEntityId", "RestaurantEntityId");

                    b.HasIndex("RestaurantEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CuisineEntity", b =>
                {
                    b.Property<int>("CuisineEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("CuisineName")
                        .HasColumnType("text");

                    b.HasKey("CuisineEntityId");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("eatIT.Database.Entity.LikedCommentsEntity", b =>
                {
                    b.Property<int>("CommentEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentEntityId1")
                        .HasColumnType("integer");

                    b.Property<int>("CommentEntityRestaurantEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("CommentEntityUserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("CommentEntityId", "UserEntityId");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("CommentEntityId1", "CommentEntityUserEntityId", "CommentEntityRestaurantEntityId");

                    b.ToTable("LikedComments");
                });

            modelBuilder.Entity("eatIT.Database.Entity.LikedRestaurantsEntity", b =>
                {
                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantEntityId")
                        .HasColumnType("integer");

                    b.HasKey("UserEntityId", "RestaurantEntityId");

                    b.HasIndex("RestaurantEntityId");

                    b.ToTable("LikedRestaurant");
                });

            modelBuilder.Entity("eatIT.Database.Entity.RestaurantCuisinesEntity", b =>
                {
                    b.Property<int>("CuisineEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("RestaurantEntityId")
                        .HasColumnType("integer");

                    b.HasKey("CuisineEntityId", "RestaurantEntityId");

                    b.HasIndex("RestaurantEntityId");

                    b.ToTable("RestaurantCuisines");
                });

            modelBuilder.Entity("eatIT.Database.Entity.RestaurantEntity", b =>
                {
                    b.Property<int>("RestaurantEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("CityEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("FeaturedIMG")
                        .HasColumnType("text");

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Locality")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("OpenHours")
                        .HasColumnType("text");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("RatingText")
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .HasColumnType("text");

                    b.Property<int>("Votes")
                        .HasColumnType("integer");

                    b.HasKey("RestaurantEntityId");

                    b.HasIndex("CityEntityId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("eatIT.Database.Entity.UserEntity", b =>
                {
                    b.Property<int>("UserEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserEntityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CommentEntity", b =>
                {
                    b.HasOne("eatIT.Database.Entity.RestaurantEntity", "RestaurantEntity")
                        .WithMany("Comments")
                        .HasForeignKey("RestaurantEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eatIT.Database.Entity.UserEntity", "UserEntity")
                        .WithMany("Comments")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("eatIT.Database.Entity.LikedCommentsEntity", b =>
                {
                    b.HasOne("eatIT.Database.Entity.UserEntity", "UserEntity")
                        .WithMany("LikedComments")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eatIT.Database.Entity.CommentEntity", "CommentEntity")
                        .WithMany("LikedComments")
                        .HasForeignKey("CommentEntityId1", "CommentEntityUserEntityId", "CommentEntityRestaurantEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CommentEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("eatIT.Database.Entity.LikedRestaurantsEntity", b =>
                {
                    b.HasOne("eatIT.Database.Entity.RestaurantEntity", "RestaurantEntity")
                        .WithMany("Users")
                        .HasForeignKey("RestaurantEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eatIT.Database.Entity.UserEntity", "UserEntity")
                        .WithMany("Restaurants")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RestaurantEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("eatIT.Database.Entity.RestaurantCuisinesEntity", b =>
                {
                    b.HasOne("eatIT.Database.Entity.CuisineEntity", "CuisineEntity")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eatIT.Database.Entity.RestaurantEntity", "RestaurantEntity")
                        .WithMany("Cuisines")
                        .HasForeignKey("RestaurantEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuisineEntity");

                    b.Navigation("RestaurantEntity");
                });

            modelBuilder.Entity("eatIT.Database.Entity.RestaurantEntity", b =>
                {
                    b.HasOne("eatIT.Database.Entity.CityEntity", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CityEntity", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CommentEntity", b =>
                {
                    b.Navigation("LikedComments");
                });

            modelBuilder.Entity("eatIT.Database.Entity.CuisineEntity", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("eatIT.Database.Entity.RestaurantEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Cuisines");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("eatIT.Database.Entity.UserEntity", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("LikedComments");

                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
