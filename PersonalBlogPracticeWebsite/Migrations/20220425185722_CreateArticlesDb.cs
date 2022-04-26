using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalBlogPracticeWebsite.Migrations
{
    public partial class CreateArticlesDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleContent",
                columns: table => new
                {
                    ArticleContentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarkDownUrl = table.Column<string>(type: "TEXT", nullable: true),
                    HtmlContent = table.Column<string>(type: "TEXT", nullable: true),
                    MarkDownContent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleContent", x => x.ArticleContentId);
                });

            migrationBuilder.CreateTable(
                name: "ArticleInfo",
                columns: table => new
                {
                    ArticleInfoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorName = table.Column<string>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleInfo", x => x.ArticleInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArticleInfoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticleContentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleContent_ArticleContentId",
                        column: x => x.ArticleContentId,
                        principalTable: "ArticleContent",
                        principalColumn: "ArticleContentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_ArticleInfo_ArticleInfoId",
                        column: x => x.ArticleInfoId,
                        principalTable: "ArticleInfo",
                        principalColumn: "ArticleInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleContentId",
                table: "Articles",
                column: "ArticleContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleInfoId",
                table: "Articles",
                column: "ArticleInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleContent");

            migrationBuilder.DropTable(
                name: "ArticleInfo");
        }
    }
}
