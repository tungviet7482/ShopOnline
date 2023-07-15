using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Data.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cart");

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("c0589cfd-c10b-4d0d-8a40-9c47764751fa"), "3aa8cac8-4b15-4a1a-b9ac-8438331e0751", null, "admin", "admin" },
                    { new Guid("e19f90b7-9ffe-457b-9e8a-9e73d2bbafcc"), "11b8b63c-16a9-4c04-8456-18e658a828b3", null, "member", "member" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c"), 0, "64ebbfcf-33f5-49a2-81ed-4978c4dcc4a1", new DateTime(2002, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "a@gmail.com", false, "Tùng", "Quang", false, null, "a@gmail.com", "a", "AQAAAAEAACcQAAAAEN5bmh0Aygl3zQtFuH7gAQSUk5FVdNOJvPid3MwYwUbza5Xa6eOWE9lkpopJ9Hk7Cg==", "01224532456", false, "9353abc8-9722-4351-a46e-d9dde027c101", false, "a" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 522, DateTimeKind.Local).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 523, DateTimeKind.Local).AddTicks(672));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 523, DateTimeKind.Local).AddTicks(687));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 523, DateTimeKind.Local).AddTicks(691));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 523, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateCreated",
                value: new DateTime(2023, 7, 14, 22, 1, 2, 523, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c0589cfd-c10b-4d0d-8a40-9c47764751fa"), new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c") });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e19f90b7-9ffe-457b-9e8a-9e73d2bbafcc"), new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c0589cfd-c10b-4d0d-8a40-9c47764751fa"), new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e19f90b7-9ffe-457b-9e8a-9e73d2bbafcc"), new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c") });

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0589cfd-c10b-4d0d-8a40-9c47764751fa"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("e19f90b7-9ffe-457b-9e8a-9e73d2bbafcc"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae1922bc-f80c-448b-aae5-7dfc8a703c7c"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Cart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
    }
}
