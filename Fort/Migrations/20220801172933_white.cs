using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class white : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Admins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Local).AddTicks(8166), new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Local).AddTicks(8179) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8151), new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8154), new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8141), new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Utc).AddTicks(8143) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Admins");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 7, 26, 9, 46, 29, 268, DateTimeKind.Local).AddTicks(5348), new DateTime(2022, 7, 26, 9, 46, 29, 268, DateTimeKind.Local).AddTicks(5409) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5301), new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5303) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5314), new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5317) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5276), new DateTime(2022, 7, 26, 8, 46, 29, 268, DateTimeKind.Utc).AddTicks(5284) });
        }
    }
}
