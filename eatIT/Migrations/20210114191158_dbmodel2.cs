﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace eatIT.Migrations
{
    public partial class dbmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CityName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Cuisines",
                columns: table => new
                {
                    CuisineEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CuisineName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisines", x => x.CuisineEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    RestaurantEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Locality = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<string>(type: "text", nullable: true),
                    Longitude = table.Column<string>(type: "text", nullable: true),
                    OpenHours = table.Column<string>(type: "text", nullable: true),
                    Thumbnail = table.Column<string>(type: "text", nullable: true),
                    FeaturedIMG = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    RatingText = table.Column<string>(type: "text", nullable: true),
                    Votes = table.Column<int>(type: "integer", nullable: false),
                    CityEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.RestaurantEntityId);
                    table.ForeignKey(
                        name: "FK_Restaurants_Cities_CityEntityId",
                        column: x => x.CityEntityId,
                        principalTable: "Cities",
                        principalColumn: "CityEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikedRestaurant",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedRestaurant", x => new { x.UserEntityId, x.RestaurantEntityId });
                    table.ForeignKey(
                        name: "FK_LikedRestaurant_Restaurants_RestaurantEntityId",
                        column: x => x.RestaurantEntityId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedRestaurant_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantCuisines",
                columns: table => new
                {
                    CuisineEntityId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantCuisines", x => new { x.CuisineEntityId, x.RestaurantEntityId });
                    table.ForeignKey(
                        name: "FK_RestaurantCuisines_Cuisines_CuisineEntityId",
                        column: x => x.CuisineEntityId,
                        principalTable: "Cuisines",
                        principalColumn: "CuisineEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantCuisines_Restaurants_RestaurantEntityId",
                        column: x => x.RestaurantEntityId,
                        principalTable: "Restaurants",
                        principalColumn: "RestaurantEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikedRestaurant_RestaurantEntityId",
                table: "LikedRestaurant",
                column: "RestaurantEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantCuisines_RestaurantEntityId",
                table: "RestaurantCuisines",
                column: "RestaurantEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_CityEntityId",
                table: "Restaurants",
                column: "CityEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedRestaurant");

            migrationBuilder.DropTable(
                name: "RestaurantCuisines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cuisines");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
