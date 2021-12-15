using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class AddRolesAndTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "ChatName", "CreationDate" },
                values: new object[,]
                {
                    { -1, "RI-390003", new DateTime(2021, 11, 30, 21, 13, 40, 34, DateTimeKind.Local).AddTicks(1534) },
                    { -2, "Gamers Room", new DateTime(2021, 12, 2, 21, 13, 40, 35, DateTimeKind.Local).AddTicks(4183) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "creator" },
                    { 2, "moderator" },
                    { 3, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "Login", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { -1, "vasia322@bbqqkk.com", "Pupok", "ahc4ahlv4lt", "+78222345678", "Vasya" },
                    { -2, "igor228@bbqqkk.com", "Uxo", "aklovfaoper", "+79221234564", "Igor" },
                    { -3, "openheart@bbqqkk.com", "Davalka", "12345", "+78921234567", "Masha" }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "FriendId", "UserId" },
                values: new object[,]
                {
                    { -2, -1 },
                    { -1, -2 },
                    { -3, -1 },
                    { -1, -3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumns: new[] { "FriendId", "UserId" },
                keyValues: new object[] { -3, -1 });

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumns: new[] { "FriendId", "UserId" },
                keyValues: new object[] { -2, -1 });

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumns: new[] { "FriendId", "UserId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumns: new[] { "FriendId", "UserId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
