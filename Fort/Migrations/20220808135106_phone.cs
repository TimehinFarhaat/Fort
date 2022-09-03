using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Local).AddTicks(9002), new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Local).AddTicks(9019) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Utc).AddTicks(8976), new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Utc).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Utc).AddTicks(8989), new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Utc).AddTicks(8989) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 8, 13, 51, 5, 964, DateTimeKind.Utc).AddTicks(2685), new DateTime(2022, 8, 8, 13, 51, 5, 964, DateTimeKind.Utc).AddTicks(2689), "$2a$11$oBEFLfMaUHuGodrS5ZjwBecPp9Z1ZhqBubZGqo89lKbkFRnTAKsIG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Doctors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Admins",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Local).AddTicks(9606), new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Local).AddTicks(9621) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Utc).AddTicks(9563), new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Utc).AddTicks(9571) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Utc).AddTicks(9585), new DateTime(2022, 8, 5, 18, 24, 1, 460, DateTimeKind.Utc).AddTicks(9585) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 24, 1, 270, DateTimeKind.Utc).AddTicks(4235), new DateTime(2022, 8, 5, 18, 24, 1, 270, DateTimeKind.Utc).AddTicks(4237), "$2a$11$5Tbtt3.a1iO/PPPxxx0WiePDaAkSUOXcft96iTrdZYQkJ3vo4IRp." });
        }
    }
}
