using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace exam.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Albums_Tracks_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Tracks",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Musicians_Tracks_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Tracks",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicianTracks",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicianTracks", x => new { x.MemberID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Albums_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Albums",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicianTracks_Musicians_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Musicians",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicLabels",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicLabels", x => new { x.FileID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_MusicLabels_Musicians_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Musicians",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[,]
                {
                    { 1, "Domain1", "Name1" },
                    { 2, "Domain1", "Name2" },
                    { 3, "Domain2", "Name3" },
                    { 4, "Domain4", "Name4" },
                    { 5, "Domain5", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "MemberID", "MemberName", "MemberNickName", "MemberSurname", "OrganizationID" },
                values: new object[,]
                {
                    { 1, "Member1", "Nick1", "Surname1", 1 },
                    { 2, "Member2", "Nick2", "Surname2", 2 },
                    { 3, "Member3", "Nick3", "Surname3", 3 },
                    { 4, "Member4", "Nick4", "Surname4", 4 },
                    { 5, "Member5", "Nick5", "Surname5", 5 }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[,]
                {
                    { 1, 1, "Description1", "TeamName1" },
                    { 2, 2, "Description2", "TeamName2" },
                    { 3, 3, "Description3", "TeamName3" },
                    { 4, 4, "Description4", "TeamName4" },
                    { 5, 5, "Description5", "TeamName5" }
                });

            migrationBuilder.InsertData(
                table: "MusicLabels",
                columns: new[] { "FileID", "TeamID", "FileExtension", "FileName", "FileSize" },
                values: new object[,]
                {
                    { 1, 1, "Extension1", "FiletName1", 1 },
                    { 2, 1, "Extension2", "FiletName2", 2 },
                    { 3, 1, "Extension3", "FiletName3", 3 },
                    { 4, 1, "Extension4", "FiletName4", 4 },
                    { 5, 1, "Extension5", "FiletName5", 5 }
                });

            migrationBuilder.InsertData(
                table: "MusicianTracks",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_OrganizationID",
                table: "Albums",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Musicians_OrganizationID",
                table: "Musicians",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicianTracks_TeamID",
                table: "MusicianTracks",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_MusicLabels_TeamID",
                table: "MusicLabels",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicianTracks");

            migrationBuilder.DropTable(
                name: "MusicLabels");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
