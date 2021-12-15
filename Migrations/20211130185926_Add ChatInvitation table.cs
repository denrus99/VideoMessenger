using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VideoMessenger.Migrations
{
    public partial class AddChatInvitationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatInvitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatInvitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatInvitation_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatInvitation_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatInvitation_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitation_ChatId",
                table: "ChatInvitation",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitation_RecipientId",
                table: "ChatInvitation",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitation_SenderId",
                table: "ChatInvitation",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatInvitation");

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

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 1, 45, 38, 132, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 2, 22, 45, 38, 132, DateTimeKind.Local).AddTicks(7437));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 11, 30, 22, 45, 38, 132, DateTimeKind.Local).AddTicks(6804));
        }
    }
}
