using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class updatedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ccf7885e-8432-4e29-97e9-255fa92dfd9f"), "7a16b5df-7f7b-4cfc-b84d-5afc9e39d244", null, "admin", null },
                    { new Guid("58a596ab-c748-490d-9cab-bc376e789551"), "b04387ea-0648-498d-94bb-ce28050fa8de", null, "member", null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea"), 0, "3affa283-bc25-4522-b9b2-48113470c463", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@gmail.com", false, "Tùng", "Quang", false, null, null, null, "AQAAAAEAACcQAAAAEDA5YHpewOKeA6qQPrVjG/M2o9g7hbbQ2ePqp/J2N+eFNdR+hStfuK1F7WnJYNmGgg==", "01224532456", false, null, false, "a" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "IsShowOnHome", "Name", "ParentId", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, true, "Đồng phục công sở", null, 1, 1 },
                    { 2, true, "Đồng phục áo Polo", 1, 2, 1 },
                    { 3, true, "Đồng phục áo sơ mi", 1, 3, 1 },
                    { 4, true, "Đồng phục ngành dịch vụ", null, 4, 1 },
                    { 5, true, "Đồng phục nhà hàng", 4, 5, 1 },
                    { 6, true, "Đồng phục kỹ thuật", null, 6, 1 },
                    { 7, true, "Đồng phục bảo hộ lao động", 6, 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "Description", "Details", "Name", "OriginalPrice", "Price", "Stock", "ViewCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 13, 21, 58, 44, 972, DateTimeKind.Local).AddTicks(5292), "Áo polo dài tay, hiện đại, lịch sự", "Áo polo dài tay, hiện đại, lịch sự", "Áo polo PL029", 200000m, 250000m, 0, 0 },
                    { 2, new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3126), "Áo polo cổ bẻ, chuẩn form, đứng dáng.", "Áo polo cổ bẻ, chuẩn form, đứng dáng.", "Áo polo PL009", 400000m, 550000m, 0, 0 },
                    { 3, new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3141), "Sơ mi cổ sen cách điệu", "Sơ mi cổ sen cách điệu", "Áo sơ mi dài tay SM026", 100000m, 150000m, 0, 0 },
                    { 4, new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3144), "Sang trọng, thanh lịch", "Sang trọng, thanh lịch", "Đồng phục nhà hàng NH010", 80000m, 100000m, 0, 0 },
                    { 5, new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3146), "Hiện đại, An toàn", "Hiện đại, An toàn", "Đồng phục bảo hộ lao động LD010", 500000m, 800000m, 0, 0 },
                    { 6, new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3147), "Hiện đại, An toàn", "Hiện đại, An toàn", "Đồng phục bảo hộ lao động LD004", 400000m, 600000m, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ccf7885e-8432-4e29-97e9-255fa92dfd9f"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("58a596ab-c748-490d-9cab-bc376e789551"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("58a596ab-c748-490d-9cab-bc376e789551"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ccf7885e-8432-4e29-97e9-255fa92dfd9f"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("58a596ab-c748-490d-9cab-bc376e789551"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("ccf7885e-8432-4e29-97e9-255fa92dfd9f"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea"));
        }
    }
}
