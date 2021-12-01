using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VideoMessenger.Migrations
{
    public partial class CreateFriendInvitationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendInvitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendInvitations_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendInvitations_Users_SenderId",
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
                value: new DateTime(2021, 12, 3, 19, 26, 32, 426, DateTimeKind.Local).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 19, 26, 32, 425, DateTimeKind.Local).AddTicks(1288));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -3,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 22, 26, 32, 426, DateTimeKind.Local).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -2,
                column: "CreationDate",
                value: new DateTime(2021, 12, 3, 19, 26, 32, 426, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreationDate",
                value: new DateTime(2021, 12, 1, 19, 26, 32, 426, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitations_RecipientId",
                table: "FriendInvitations",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitations_SenderId",
                table: "FriendInvitations",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendInvitations");

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
        }
    }
}
