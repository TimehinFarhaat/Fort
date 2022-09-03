using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class worth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Gender", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Local).AddTicks(3695), "Female", new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Local).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3679), new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3682), new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3683) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3661), new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3664) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Gender", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Local).AddTicks(8166), null, new DateTime(2022, 8, 1, 17, 29, 32, 409, DateTimeKind.Local).AddTicks(8179) });

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
    }
}
