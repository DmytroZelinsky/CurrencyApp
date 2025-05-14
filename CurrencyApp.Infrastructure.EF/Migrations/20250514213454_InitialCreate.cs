using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CurrencyApp.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolePK = table.Column<byte>(type: "tinyint", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolePK);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserPK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolePK = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserPK);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolePK",
                        column: x => x.RolePK,
                        principalTable: "Roles",
                        principalColumn: "RolePK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolePK", "RoleName" },
                values: new object[,]
                {
                    { (byte)1, "Admin" },
                    { (byte)2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserPK", "PasswordHash", "RolePK", "UserName" },
                values: new object[,]
                {
                    { new Guid("b9ce9477-7eb6-4444-b411-554895bf3272"), "25-F4-3B-14-86-AD-95-A1-39-8E-3E-EB-3D-83-BC-40-10-01-5F-CC-9B-ED-B3-5B-43-2E-00-29-8D-50-21-F7", (byte)1, "admin1" },
                    { new Guid("fe16b2fd-ab54-4a10-b69e-a43215ed7a75"), "0A-04-1B-94-62-CA-A4-A3-1B-AC-35-67-E0-B6-E6-FD-91-00-78-7D-B2-AB-43-3D-96-F6-D1-78-CA-BF-CE-90", (byte)2, "user1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolePK",
                table: "Users",
                column: "RolePK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
