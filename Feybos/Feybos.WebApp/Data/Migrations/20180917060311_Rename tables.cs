using Microsoft.EntityFrameworkCore.Migrations;

namespace Feybos.WebApp.Data.Migrations
{
    public partial class Renametables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "CoreUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "CoreUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "CoreUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "CoreUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "CoreUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "CoreRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "CoreRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "CoreUserRoles",
                newName: "IX_CoreUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "CoreUserLogins",
                newName: "IX_CoreUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "CoreUserClaims",
                newName: "IX_CoreUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "CoreRoleClaims",
                newName: "IX_CoreRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreUserTokens",
                table: "CoreUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreUsers",
                table: "CoreUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreUserRoles",
                table: "CoreUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreUserLogins",
                table: "CoreUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreUserClaims",
                table: "CoreUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreRoles",
                table: "CoreRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CoreRoleClaims",
                table: "CoreRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoreRoleClaims_CoreRoles_RoleId",
                table: "CoreRoleClaims",
                column: "RoleId",
                principalTable: "CoreRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreUserClaims_CoreUsers_UserId",
                table: "CoreUserClaims",
                column: "UserId",
                principalTable: "CoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreUserLogins_CoreUsers_UserId",
                table: "CoreUserLogins",
                column: "UserId",
                principalTable: "CoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreUserRoles_CoreRoles_RoleId",
                table: "CoreUserRoles",
                column: "RoleId",
                principalTable: "CoreRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreUserRoles_CoreUsers_UserId",
                table: "CoreUserRoles",
                column: "UserId",
                principalTable: "CoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoreUserTokens_CoreUsers_UserId",
                table: "CoreUserTokens",
                column: "UserId",
                principalTable: "CoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoreRoleClaims_CoreRoles_RoleId",
                table: "CoreRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreUserClaims_CoreUsers_UserId",
                table: "CoreUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreUserLogins_CoreUsers_UserId",
                table: "CoreUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreUserRoles_CoreRoles_RoleId",
                table: "CoreUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreUserRoles_CoreUsers_UserId",
                table: "CoreUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_CoreUserTokens_CoreUsers_UserId",
                table: "CoreUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreUserTokens",
                table: "CoreUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreUsers",
                table: "CoreUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreUserRoles",
                table: "CoreUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreUserLogins",
                table: "CoreUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreUserClaims",
                table: "CoreUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreRoles",
                table: "CoreRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CoreRoleClaims",
                table: "CoreRoleClaims");

            migrationBuilder.RenameTable(
                name: "CoreUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "CoreUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "CoreUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "CoreUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "CoreUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "CoreRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "CoreRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_CoreUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_CoreUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoreUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CoreRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
