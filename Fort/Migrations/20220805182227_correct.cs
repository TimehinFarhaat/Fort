using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Local).AddTicks(822), new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Utc).AddTicks(788), new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Utc).AddTicks(791) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Utc).AddTicks(805), new DateTime(2022, 8, 5, 18, 22, 26, 595, DateTimeKind.Utc).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 5, 18, 22, 26, 416, DateTimeKind.Utc).AddTicks(4712), new DateTime(2022, 8, 5, 18, 22, 26, 416, DateTimeKind.Utc).AddTicks(4716), "$2a$11$1DH4tK1qZ6zDNoC9dhHSruIO5pyXO7Rm.Z7mLaJzkqAi51iLrRtFy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Local).AddTicks(3695), new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Local).AddTicks(3710) });

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
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3661), new DateTime(2022, 8, 1, 17, 32, 26, 984, DateTimeKind.Utc).AddTicks(3664), "12345" });
        }
    }
}
