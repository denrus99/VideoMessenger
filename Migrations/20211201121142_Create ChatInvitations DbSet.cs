using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class CreateChatInvitationsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_Chats_ChatId",
                table: "ChatInvitation");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_Users_RecipientId",
                table: "ChatInvitation");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitation_Users_SenderId",
                table: "ChatInvitation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatInvitation",
                table: "ChatInvitation");

            migrationBuilder.RenameTable(
                name: "ChatInvitation",
                newName: "ChatInvitations");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_SenderId",
                table: "ChatInvitations",
                newName: "IX_ChatInvitations_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_RecipientId",
                table: "ChatInvitations",
                newName: "IX_ChatInvitations_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitation_ChatId",
                table: "ChatInvitations",
                newName: "IX_ChatInvitations_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatInvitations",
                table: "ChatInvitations",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 17, 11, 42, 171, DateTimeKind.Local).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 17, 11, 42, 170, DateTimeKind.Local).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 20, 11, 42, 171, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 17, 11, 42, 171, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 17, 11, 42, 171, DateTimeKind.Local).AddTicks(8486));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitations_Chats_ChatId",
                table: "ChatInvitations",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitations_Users_RecipientId",
                table: "ChatInvitations",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitations_Users_SenderId",
                table: "ChatInvitations",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitations_Chats_ChatId",
                table: "ChatInvitations");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitations_Users_RecipientId",
                table: "ChatInvitations");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatInvitations_Users_SenderId",
                table: "ChatInvitations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatInvitations",
                table: "ChatInvitations");

            migrationBuilder.RenameTable(
                name: "ChatInvitations",
                newName: "ChatInvitation");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitations_SenderId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitations_RecipientId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_RecipientId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatInvitations_ChatId",
                table: "ChatInvitation",
                newName: "IX_ChatInvitation_ChatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatInvitation",
                table: "ChatInvitation",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 23, 59, 25, 801, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 23, 59, 25, 800, DateTimeKind.Local).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 2, 59, 25, 801, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 23, 59, 25, 801, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 23, 59, 25, 801, DateTimeKind.Local).AddTicks(9294));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_Chats_ChatId",
                table: "ChatInvitation",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_Users_RecipientId",
                table: "ChatInvitation",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatInvitation_Users_SenderId",
                table: "ChatInvitation",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
