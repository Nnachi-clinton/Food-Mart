using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMartInfrastructure.Migrations
{
    public partial class sSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86775989-995d-4050-a2f3-8e1ce9a0552a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a616aadc-c997-469b-8b26-4a793966931e");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Vendors",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Vendors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55fb94f9-0ae9-46c5-a283-6736c8ceda8a", "1", "Vendor", "Vendor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "57a7696d-69ee-4754-a41e-fdd3e734a92c", "0", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55fb94f9-0ae9-46c5-a283-6736c8ceda8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a7696d-69ee-4754-a41e-fdd3e734a92c");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Vendors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86775989-995d-4050-a2f3-8e1ce9a0552a", "1", "Vendor", "Vendor" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a616aadc-c997-469b-8b26-4a793966931e", "0", "User", "User" });
        }
    }
}
