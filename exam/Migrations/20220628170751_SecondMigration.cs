using Microsoft.EntityFrameworkCore.Migrations;

namespace exam.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Tracks_OrganizationID",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Musicians_Tracks_OrganizationID",
                table: "Musicians");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTracks_Albums_MemberID",
                table: "MusicianTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicianTracks_Musicians_TeamID",
                table: "MusicianTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicLabels_Musicians_TeamID",
                table: "MusicLabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicLabels",
                table: "MusicLabels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicianTracks",
                table: "MusicianTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musicians",
                table: "Musicians");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "Tracks",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "MusicLabels",
                newName: "Files");

            migrationBuilder.RenameTable(
                name: "MusicianTracks",
                newName: "Memberships");

            migrationBuilder.RenameTable(
                name: "Musicians",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Members");

            migrationBuilder.RenameIndex(
                name: "IX_MusicLabels_TeamID",
                table: "Files",
                newName: "IX_Files_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_MusicianTracks_TeamID",
                table: "Memberships",
                newName: "IX_Memberships_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Musicians_OrganizationID",
                table: "Teams",
                newName: "IX_Teams_OrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_OrganizationID",
                table: "Members",
                newName: "IX_Members_OrganizationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "OrganizationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Files",
                table: "Files",
                columns: new[] { "FileID", "TeamID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships",
                columns: new[] { "MemberID", "TeamID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Teams_TeamID",
                table: "Files",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Organizations_OrganizationID",
                table: "Members",
                column: "OrganizationID",
                principalTable: "Organizations",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Members_MemberID",
                table: "Memberships",
                column: "MemberID",
                principalTable: "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memberships_Teams_TeamID",
                table: "Memberships",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Organizations_OrganizationID",
                table: "Teams",
                column: "OrganizationID",
                principalTable: "Organizations",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Teams_TeamID",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Organizations_OrganizationID",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Members_MemberID",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Memberships_Teams_TeamID",
                table: "Memberships");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Organizations_OrganizationID",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memberships",
                table: "Memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Files",
                table: "Files");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Musicians");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Tracks");

            migrationBuilder.RenameTable(
                name: "Memberships",
                newName: "MusicianTracks");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Albums");

            migrationBuilder.RenameTable(
                name: "Files",
                newName: "MusicLabels");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_OrganizationID",
                table: "Musicians",
                newName: "IX_Musicians_OrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_Memberships_TeamID",
                table: "MusicianTracks",
                newName: "IX_MusicianTracks_TeamID");

            migrationBuilder.RenameIndex(
                name: "IX_Members_OrganizationID",
                table: "Albums",
                newName: "IX_Albums_OrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_Files_TeamID",
                table: "MusicLabels",
                newName: "IX_MusicLabels_TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musicians",
                table: "Musicians",
                column: "TeamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tracks",
                table: "Tracks",
                column: "OrganizationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicianTracks",
                table: "MusicianTracks",
                columns: new[] { "MemberID", "TeamID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "MemberID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicLabels",
                table: "MusicLabels",
                columns: new[] { "FileID", "TeamID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Tracks_OrganizationID",
                table: "Albums",
                column: "OrganizationID",
                principalTable: "Tracks",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Musicians_Tracks_OrganizationID",
                table: "Musicians",
                column: "OrganizationID",
                principalTable: "Tracks",
                principalColumn: "OrganizationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTracks_Albums_MemberID",
                table: "MusicianTracks",
                column: "MemberID",
                principalTable: "Albums",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicianTracks_Musicians_TeamID",
                table: "MusicianTracks",
                column: "TeamID",
                principalTable: "Musicians",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicLabels_Musicians_TeamID",
                table: "MusicLabels",
                column: "TeamID",
                principalTable: "Musicians",
                principalColumn: "TeamID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
