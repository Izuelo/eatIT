using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace eatIT.Migrations
{
    public partial class keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_Comments_CommentEntityId1_CommentEntityUserEn~",
                table: "LikedComments");

            migrationBuilder.DropIndex(
                name: "IX_LikedComments_CommentEntityId1_CommentEntityUserEntityId_Co~",
                table: "LikedComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentEntityId1",
                table: "LikedComments");

            migrationBuilder.DropColumn(
                name: "CommentEntityRestaurantEntityId",
                table: "LikedComments");

            migrationBuilder.DropColumn(
                name: "CommentEntityUserEntityId",
                table: "LikedComments");

            migrationBuilder.AlterColumn<int>(
                name: "CommentEntityId",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CommentEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_Comments_CommentEntityId",
                table: "LikedComments",
                column: "CommentEntityId",
                principalTable: "Comments",
                principalColumn: "CommentEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_Comments_CommentEntityId",
                table: "LikedComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CommentEntityId1",
                table: "LikedComments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentEntityRestaurantEntityId",
                table: "LikedComments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentEntityUserEntityId",
                table: "LikedComments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CommentEntityId",
                table: "Comments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "CommentEntityId", "UserEntityId", "RestaurantEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_LikedComments_CommentEntityId1_CommentEntityUserEntityId_Co~",
                table: "LikedComments",
                columns: new[] { "CommentEntityId1", "CommentEntityUserEntityId", "CommentEntityRestaurantEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_Comments_CommentEntityId1_CommentEntityUserEn~",
                table: "LikedComments",
                columns: new[] { "CommentEntityId1", "CommentEntityUserEntityId", "CommentEntityRestaurantEntityId" },
                principalTable: "Comments",
                principalColumns: new[] { "CommentEntityId", "UserEntityId", "RestaurantEntityId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
