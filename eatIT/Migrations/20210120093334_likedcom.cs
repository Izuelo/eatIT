using Microsoft.EntityFrameworkCore.Migrations;

namespace eatIT.Migrations
{
    public partial class likedcom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "NegativeScore",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositiveScore",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "CommentEntityId", "UserEntityId", "RestaurantEntityId" });

            migrationBuilder.CreateTable(
                name: "LikedComments",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    CommentEntityId = table.Column<int>(type: "integer", nullable: false),
                    CommentEntityId1 = table.Column<int>(type: "integer", nullable: false),
                    CommentEntityUserEntityId = table.Column<int>(type: "integer", nullable: false),
                    CommentEntityRestaurantEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikedComments", x => new { x.CommentEntityId, x.UserEntityId });
                    table.ForeignKey(
                        name: "FK_LikedComments_Comments_CommentEntityId1_CommentEntityUserEn~",
                        columns: x => new { x.CommentEntityId1, x.CommentEntityUserEntityId, x.CommentEntityRestaurantEntityId },
                        principalTable: "Comments",
                        principalColumns: new[] { "CommentEntityId", "UserEntityId", "RestaurantEntityId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikedComments_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserEntityId",
                table: "Comments",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LikedComments_CommentEntityId1_CommentEntityUserEntityId_Co~",
                table: "LikedComments",
                columns: new[] { "CommentEntityId1", "CommentEntityUserEntityId", "CommentEntityRestaurantEntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_LikedComments_UserEntityId",
                table: "LikedComments",
                column: "UserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikedComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserEntityId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "NegativeScore",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PositiveScore",
                table: "Comments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "UserEntityId", "RestaurantEntityId" });
        }
    }
}
