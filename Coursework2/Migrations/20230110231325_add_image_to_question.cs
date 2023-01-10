using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MANwork.Migrations
{
    public partial class add_image_to_question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<byte[]>(type: "BLOB", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leading",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leading", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageOfQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PackageEditor = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageOfQuestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdLeading = table.Column<int>(type: "INTEGER", nullable: false),
                    NameOfGame = table.Column<string>(type: "TEXT", nullable: true),
                    IdPackageQuestions = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSession_Leading_IdLeading",
                        column: x => x.IdLeading,
                        principalTable: "Leading",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSession_PackageOfQuestions_IdPackageQuestions",
                        column: x => x.IdPackageQuestions,
                        principalTable: "PackageOfQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPackage = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: true),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    IdImage = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Images_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questions_PackageOfQuestions_IdPackage",
                        column: x => x.IdPackage,
                        principalTable: "PackageOfQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSession = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientSession_GameSession_IdSession",
                        column: x => x.IdSession,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientSession_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdSession = table.Column<int>(type: "INTEGER", nullable: false),
                    IdQuestion = table.Column<int>(type: "INTEGER", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: true),
                    StartQuestion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndQuestion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentQuestion_GameSession_IdSession",
                        column: x => x.IdSession,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentQuestion_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCurrentQuestion = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUsers = table.Column<int>(type: "INTEGER", nullable: false),
                    IdSession = table.Column<int>(type: "INTEGER", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    Credited = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentAnswer_CurrentQuestion_IdCurrentQuestion",
                        column: x => x.IdCurrentQuestion,
                        principalTable: "CurrentQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAnswer_GameSession_IdSession",
                        column: x => x.IdSession,
                        principalTable: "GameSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentAnswer_Users_IdUsers",
                        column: x => x.IdUsers,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientSession_IdSession",
                table: "ClientSession",
                column: "IdSession");

            migrationBuilder.CreateIndex(
                name: "IX_ClientSession_IdUser",
                table: "ClientSession",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAnswer_IdCurrentQuestion",
                table: "CurrentAnswer",
                column: "IdCurrentQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAnswer_IdSession",
                table: "CurrentAnswer",
                column: "IdSession");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAnswer_IdUsers",
                table: "CurrentAnswer",
                column: "IdUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentQuestion_IdQuestion",
                table: "CurrentQuestion",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentQuestion_IdSession",
                table: "CurrentQuestion",
                column: "IdSession");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_IdLeading",
                table: "GameSession",
                column: "IdLeading");

            migrationBuilder.CreateIndex(
                name: "IX_GameSession_IdPackageQuestions",
                table: "GameSession",
                column: "IdPackageQuestions");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdImage",
                table: "Questions",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdPackage",
                table: "Questions",
                column: "IdPackage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientSession");

            migrationBuilder.DropTable(
                name: "CurrentAnswer");

            migrationBuilder.DropTable(
                name: "CurrentQuestion");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "GameSession");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Leading");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "PackageOfQuestions");
        }
    }
}
