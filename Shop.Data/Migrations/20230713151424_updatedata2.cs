using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class updatedata2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9a117e57-0ac5-4bc7-8636-78ff70094336"), "c1c36c12-ec63-4b94-b9e2-bc9f94343aa0", null, "admin", null },
                    { new Guid("deea7219-e233-49fa-ba0d-4b217591ab01"), "58fa5e48-e950-46de-aa51-ce1a4bb4fe26", null, "member", null }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0"), 0, "fb4ea9cf-6149-4a52-b9ad-2783e9133aa1", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@gmail.com", false, "Tùng", "Quang", false, null, null, null, "AQAAAAEAACcQAAAAEB9FwlM7G+L4P+FYcytGmV1ZURoN1rAUOPUX1cwWpESCRsNGFy4BK7FNf4zr4nSnbQ==", "01224532456", false, null, false, "a" });

            migrationBuilder.InsertData(
                table: "ProductInCategory",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 5, 4 },
                    { 7, 5 },
                    { 7, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 168, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 169, DateTimeKind.Local).AddTicks(2501));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 169, DateTimeKind.Local).AddTicks(2517));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 169, DateTimeKind.Local).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 169, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 22, 14, 24, 169, DateTimeKind.Local).AddTicks(2522));

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9a117e57-0ac5-4bc7-8636-78ff70094336"), new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0") });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("deea7219-e233-49fa-ba0d-4b217591ab01"), new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9a117e57-0ac5-4bc7-8636-78ff70094336"), new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("deea7219-e233-49fa-ba0d-4b217591ab01"), new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0") });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "ProductInCategory",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a117e57-0ac5-4bc7-8636-78ff70094336"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("deea7219-e233-49fa-ba0d-4b217591ab01"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("0d02e8ad-ebc8-4b58-93a2-094932fd07a0"));

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 972, DateTimeKind.Local).AddTicks(5292));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 13, 21, 58, 44, 973, DateTimeKind.Local).AddTicks(3147));

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ccf7885e-8432-4e29-97e9-255fa92dfd9f"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("58a596ab-c748-490d-9cab-bc376e789551"), new Guid("0458c133-ce6f-443d-9ec4-7d0a5576f1ea") });
        }
    }
}
