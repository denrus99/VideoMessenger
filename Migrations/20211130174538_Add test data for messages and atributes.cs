using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class Addtestdataformessagesandatributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 22, 45, 38, 132, DateTimeKind.Local).AddTicks(4979));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 22, 45, 38, 131, DateTimeKind.Local).AddTicks(4484));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreationDate", "Data", "IsReaded", "SenderId" },
                values: new object[,]
                {
                    { -1, -1, new DateTime(2021, 11, 30, 22, 45, 38, 132, DateTimeKind.Local).AddTicks(6804), "Hello, World!", false, -1 },
                    { -2, -2, new DateTime(2021, 12, 2, 22, 45, 38, 132, DateTimeKind.Local).AddTicks(7437), "Good bye, World!", true, -2 },
                    { -3, -2, new DateTime(2021, 12, 1, 1, 45, 38, 132, DateTimeKind.Local).AddTicks(7450), "My life be like, uuuuaaaa", false, -3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 22, 25, 45, 168, DateTimeKind.Local).AddTicks(4916));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 22, 25, 45, 167, DateTimeKind.Local).AddTicks(4179));
        }
    }
}
