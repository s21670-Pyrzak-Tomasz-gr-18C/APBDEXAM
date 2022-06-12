using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace exam.Migrations
{
	public partial class InitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Musicians",
				columns: table => new
				{
					IdMusician = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Nickname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Musicians", x => x.IdMusician);
				});

			migrationBuilder.CreateTable(
				name: "MusicLabels",
				columns: table => new
				{
					IdMusicLabel = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MusicLabels", x => x.IdMusicLabel);
				});

			migrationBuilder.CreateTable(
				name: "Albums",
				columns: table => new
				{
					IdAlbum = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					AlbumName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
					PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IdMusicLabel = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Albums", x => x.IdAlbum);
					table.ForeignKey(
						name: "FK_Albums_MusicLabels_IdMusicLabel",
						column: x => x.IdMusicLabel,
						principalTable: "MusicLabels",
						principalColumn: "IdMusicLabel",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tracks",
				columns: table => new
				{
					IdTrack = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					TrackName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
					Duration = table.Column<float>(type: "real", nullable: false),
					IdMusicAlbum = table.Column<int>(type: "int", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tracks", x => x.IdTrack);
					table.ForeignKey(
						name: "FK_Tracks_Albums_IdMusicAlbum",
						column: x => x.IdMusicAlbum,
						principalTable: "Albums",
						principalColumn: "IdAlbum",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "MusicianTracks",
				columns: table => new
				{
					IdTrack = table.Column<int>(type: "int", nullable: false),
					IdMusician = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_MusicianTracks", x => new { x.IdTrack, x.IdMusician });
					table.ForeignKey(
						name: "FK_MusicianTracks_Musicians_IdMusician",
						column: x => x.IdMusician,
						principalTable: "Musicians",
						principalColumn: "IdMusician",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_MusicianTracks_Tracks_IdTrack",
						column: x => x.IdTrack,
						principalTable: "Tracks",
						principalColumn: "IdTrack",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "MusicLabels",
				columns: new[] { "IdMusicLabel", "Name" },
				values: new object[,]
				{
					{ 1, "MusicLabel1" },
					{ 2, "MusicLabel2" },
					{ 3, "MusicLabel3" },
					{ 4, "MusicLabel4" },
					{ 5, "MusicLabel5" }
				});

			migrationBuilder.InsertData(
				table: "Musicians",
				columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
				values: new object[,]
				{
					{ 1, "FirstName1", "LastName1", "Nickname1" },
					{ 2, "FirstName2", "LastName2", "Nickname2" },
					{ 3, "FirstName3", "LastName3", "Nickname3" },
					{ 4, "FirstName4", "LastName4", "Nickname4" },
					{ 5, "FirstName5", "LastName5", "Nickname5" }
				});

			migrationBuilder.InsertData(
				table: "Albums",
				columns: new[] { "IdAlbum", "AlbumName", "IdMusicLabel", "PublishDate" },
				values: new object[,]
				{
					{ 1, "AlbumName1", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
					{ 2, "AlbumName2", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
					{ 3, "AlbumName3", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
					{ 4, "AlbumName4", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
					{ 5, "AlbumName5", 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
				});

			migrationBuilder.InsertData(
				table: "Tracks",
				columns: new[] { "IdTrack", "Duration", "IdMusicAlbum", "TrackName" },
				values: new object[,]
				{
					{ 1, 1f, 1, "Track1" },
					{ 2, 1f, 2, "Track2" },
					{ 3, 1f, 3, "Track3" },
					{ 4, 1f, 4, "Track4" },
					{ 5, 1f, 5, "Track5" }
				});

			migrationBuilder.InsertData(
				table: "MusicianTracks",
				columns: new[] { "IdMusician", "IdTrack" },
				values: new object[,]
				{
					{ 1, 1 },
					{ 1, 2 },
					{ 1, 3 },
					{ 2, 4 },
					{ 3, 5 }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Albums_IdMusicLabel",
				table: "Albums",
				column: "IdMusicLabel");

			migrationBuilder.CreateIndex(
				name: "IX_MusicianTracks_IdMusician",
				table: "MusicianTracks",
				column: "IdMusician");

			migrationBuilder.CreateIndex(
				name: "IX_Tracks_IdMusicAlbum",
				table: "Tracks",
				column: "IdMusicAlbum");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "MusicianTracks");

			migrationBuilder.DropTable(
				name: "Musicians");

			migrationBuilder.DropTable(
				name: "Tracks");

			migrationBuilder.DropTable(
				name: "Albums");

			migrationBuilder.DropTable(
				name: "MusicLabels");
		}
	}
}
