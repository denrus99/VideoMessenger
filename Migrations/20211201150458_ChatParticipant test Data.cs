using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class ChatParticipanttestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -3, -3 });

            migrationBuilder.UpdateData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -2, -3 },
                column: "RoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 4, 58, 270, DateTimeKind.Local).AddTicks(9470));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 4, 58, 269, DateTimeKind.Local).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 23, 4, 58, 271, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 4, 58, 271, DateTimeKind.Local).AddTicks(2162));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 4, 58, 271, DateTimeKind.Local).AddTicks(1612));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ChatParticipants",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { -2, -3 },
                column: "RoleId",
                value: 2);

            migrationBuilder.InsertData(
                table: "ChatParticipants",
                columns: new[] { "ChatId", "UserId", "RoleId" },
                values: new object[] { -3, -3, 1 });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 1, 9, 844, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 1, 9, 842, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 23, 1, 9, 844, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 20, 1, 9, 844, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 1, 9, 844, DateTimeKind.Local).AddTicks(4262));
        }
    }
}
