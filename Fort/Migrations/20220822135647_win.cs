using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class win : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 15, 9, 42, 53, 876, DateTimeKind.Local).AddTicks(1135), new DateTime(2022, 8, 15, 9, 42, 53, 876, DateTimeKind.Local).AddTicks(1155) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 15, 8, 42, 53, 876, DateTimeKind.Utc).AddTicks(1101), new DateTime(2022, 8, 15, 8, 42, 53, 876, DateTimeKind.Utc).AddTicks(1107) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 15, 8, 42, 53, 876, DateTimeKind.Utc).AddTicks(1121), new DateTime(2022, 8, 15, 8, 42, 53, 876, DateTimeKind.Utc).AddTicks(1122) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord" },
                values: new object[] { new DateTime(2022, 8, 15, 8, 42, 53, 675, DateTimeKind.Utc).AddTicks(2385), new DateTime(2022, 8, 15, 8, 42, 53, 675, DateTimeKind.Utc).AddTicks(2387), "$2a$11$3zWYEIQRIW90oLr/uNItUu0se75I4gFYQHQE.Gac/bI/KScaj0LOK" });
        }
    }
}
