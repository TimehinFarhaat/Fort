using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class rate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 25, 18, 36, 53, 845, DateTimeKind.Local).AddTicks(5492), new DateTime(2022, 8, 25, 18, 36, 53, 845, DateTimeKind.Local).AddTicks(5517) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 25, 17, 36, 53, 845, DateTimeKind.Utc).AddTicks(5455), new DateTime(2022, 8, 25, 17, 36, 53, 845, DateTimeKind.Utc).AddTicks(5459) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 25, 17, 36, 53, 845, DateTimeKind.Utc).AddTicks(5473), new DateTime(2022, 8, 25, 17, 36, 53, 845, DateTimeKind.Utc).AddTicks(5473) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 25, 17, 36, 53, 541, DateTimeKind.Utc).AddTicks(6718), new DateTime(2022, 8, 25, 17, 36, 53, 541, DateTimeKind.Utc).AddTicks(6721), "$2a$11$U6zmX7REwj1vYQpxPWgC.ulbX9YeV60soAKm80pN9D3wHkCbHCx3y" });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AnswerId",
                table: "Ratings",
                column: "AnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 22, 14, 56, 46, 955, DateTimeKind.Local).AddTicks(2582), new DateTime(2022, 8, 22, 14, 56, 46, 955, DateTimeKind.Local).AddTicks(2605) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 22, 13, 56, 46, 955, DateTimeKind.Utc).AddTicks(2544), new DateTime(2022, 8, 22, 13, 56, 46, 955, DateTimeKind.Utc).AddTicks(2552) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 22, 13, 56, 46, 955, DateTimeKind.Utc).AddTicks(2568), new DateTime(2022, 8, 22, 13, 56, 46, 955, DateTimeKind.Utc).AddTicks(2568) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 22, 13, 56, 46, 779, DateTimeKind.Utc).AddTicks(6050), new DateTime(2022, 8, 22, 13, 56, 46, 779, DateTimeKind.Utc).AddTicks(6053), "$2a$11$zKoDcBUpAUQZXscsBXLqeezJtq6O81Xcf3.tm8IFrvGNRScHUwUwC" });
        }
    }
}
