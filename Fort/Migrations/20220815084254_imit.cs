using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fort.Migrations
{
    public partial class imit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord", "PhoneNumber" },
                values: new object[] { new DateTime(2022, 8, 15, 8, 42, 53, 675, DateTimeKind.Utc).AddTicks(2385), new DateTime(2022, 8, 15, 8, 42, 53, 675, DateTimeKind.Utc).AddTicks(2387), "$2a$11$3zWYEIQRIW90oLr/uNItUu0se75I4gFYQHQE.Gac/bI/KScaj0LOK", "0804675464" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CreatedOn", "LastModifiedOn", "PassWord", "PhoneNumber" },
                values: new object[] { new DateTime(2022, 8, 11, 10, 43, 58, 793, DateTimeKind.Utc).AddTicks(356), new DateTime(2022, 8, 11, 10, 43, 58, 793, DateTimeKind.Utc).AddTicks(359), "$2a$11$rfEfYqBjsgJrngeDU//0H.hC1w2OCG49xx1VKyEgZYQlrds3jHkvW", null });
        }
    }
}
