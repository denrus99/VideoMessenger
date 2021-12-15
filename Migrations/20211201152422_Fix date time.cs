using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class Fixdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -2, -3 });

            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -2, -2 });

            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -1, -3 });

            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -1, -2 });

            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -1, -1 });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 20, 16, 11, 191, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 16, 11, 191, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 10, 3, 20, 16, 11, 191, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 11, 2, 21, 16, 11, 191, DateTimeKind.Local).AddTicks(4330));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatParticipants",
                columns: new[] { "ChatId", "UserId", "RoleId" },
                values: new object[,]
                {
                    { -1, -1, 1 },
                    { -1, -2, 2 },
                    { -2, -2, 1 },
                    { -2, -3, 1 },
                    { -1, -3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 16, 11, 191, DateTimeKind.Local).AddTicks(1094));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 16, 11, 189, DateTimeKind.Local).AddTicks(5674));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 23, 16, 11, 191, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 16, 11, 191, DateTimeKind.Local).AddTicks(5612));
        }
    }
}
