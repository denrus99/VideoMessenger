using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class Addatributesforsometables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 21, 13, 40, 35, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 21, 13, 40, 34, DateTimeKind.Local).AddTicks(1534));
        }
    }
}
