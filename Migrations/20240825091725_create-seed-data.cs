using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class createseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Customer", "CUSTOMER" },
                    { "3", null, "Support", "SUPPORT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiaryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "8ae9215d-9324-4cc6-aa96-2bcd41f7497a", "admin@example.com", true, null, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECof6MqOOVnAGoKyyReygtaUORR7JsI+5eBenDGVz99ueIg3oCTWqib7CQAlbUs2BQ==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7a88d39e-e38e-47e5-96ec-2c21dfddfe71", false, "admin@example.com" },
                    { "2", 0, "42670424-a838-4f75-a8f8-24897f6ccd58", "customer@example.com", true, null, false, null, "CUSTOMER@EXAMPLE.COM", "CUSTOMER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIYXyi3jFDuP94XJtgRENdpF7wO06rAShscguur5KKloOl7l3gO0N7GnCMBW1P3C0Q==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d8a3c50e-e820-4d5a-ad1c-08f72a5fb61b", false, "customer@example.com" },
                    { "3", 0, "94d0775d-f349-4947-a335-ef50527f1232", "support@example.com", true, null, false, null, "SUPPORT@EXAMPLE.COM", "SUPPORT@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAmRGLs7/paRgsNR0c0iPG+46PPEwYJMJDYZWqRNl3rreP+3EpLE5hZrtLl6zqPIUQ==", null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "d660d541-e57d-4c1a-a8cd-64adf35c53e3", false, "support@example.com" }
                });

            migrationBuilder.InsertData(
                table: "TicketActions",
                columns: new[] { "ActionId", "ActionName" },
                values: new object[,]
                {
                    { 1, "Created" },
                    { 2, "Assigned" },
                    { 3, "In Progress" },
                    { 4, "Resolved" },
                    { 5, "Closed" },
                    { 6, "Reopened" },
                    { 7, "Escalated" },
                    { 8, "On Hold" },
                    { 9, "Awaiting Customer Response" },
                    { 10, "Awaiting Internal Review" }
                });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Technical Support" },
                    { 2, "Customer Service" },
                    { 3, "Billing and Payments" },
                    { 4, "Product Feedback" },
                    { 5, "Account Management" },
                    { 6, "Order Processing" },
                    { 7, "System Maintenance" },
                    { 8, "Security Issues" },
                    { 9, "Training and Documentation" },
                    { 10, "Compliance and Regulations" }
                });

            migrationBuilder.InsertData(
                table: "TicketPriorities",
                columns: new[] { "PriorityId", "PriorityName" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" }
                });

            migrationBuilder.InsertData(
                table: "TicketStatuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TicketActions",
                keyColumn: "ActionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "PriorityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "PriorityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketPriorities",
                keyColumn: "PriorityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketStatuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
