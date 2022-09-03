using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class water : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Local).AddTicks(1346), new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Local).AddTicks(1364) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Utc).AddTicks(1311), new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Utc).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Utc).AddTicks(1331), new DateTime(2022, 8, 11, 10, 43, 58, 974, DateTimeKind.Utc).AddTicks(1332) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Age", "CreatedOn", "Gender", "LastModifiedOn", "PassWord" },
                values: new object[] { 64, new DateTime(2022, 8, 11, 10, 43, 58, 793, DateTimeKind.Utc).AddTicks(356), "Female", new DateTime(2022, 8, 11, 10, 43, 58, 793, DateTimeKind.Utc).AddTicks(359), "$2a$11$rfEfYqBjsgJrngeDU//0H.hC1w2OCG49xx1VKyEgZYQlrds3jHkvW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patients",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedOn", "Gender", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Local).AddTicks(9002), "Female", new DateTime(2022, 8, 8, 13, 51, 6, 120, DateTimeKind.Local).AddTicks(9019) });

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
    }
}
