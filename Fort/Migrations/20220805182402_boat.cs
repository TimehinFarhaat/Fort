using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class boat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
