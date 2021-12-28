using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VideoMessenger.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatName = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatInvitations",
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
                    table.PrimaryKey("PK_ChatInvitations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatInvitations_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatInvitations_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatInvitations_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatParticipants",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatParticipants", x => new { x.ChatId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatParticipants_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FriendId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.FriendId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Friends_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsReaded = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "ChatName", "CreationDate" },
                values: new object[,]
                {
                    { -1, "RI-390003", new DateTime(2021, 12, 16, 13, 16, 0, 0, DateTimeKind.Local) },
                    { -2, "Gamers Room", new DateTime(2021, 12, 2, 20, 16, 11, 191, DateTimeKind.Local) }
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
                    { -1, "vasya322@ya.ru", "Pupok", "$2a$11$aM0vfoLUHEqor6PfJZuiruGpPWtaWz3Q9lu1yja20fYme4A.1gIZ6", "+78222345678", "Vasya" },
                    { -2, "igor2005@ya.ru", "Uxo", "$2a$11$g5CtJNIfcaPEdaMtYU1Kb.JD8UrjOJu3S.9cEIsCC4TdAVxFffNHi", "+79221234564", "Igor" },
                    { -3, "sodeep@ya.ru", "Poland", "$2a$11$/Fo41l/YUEU4L6iPU2m7M.ZXj8Fp571mTw/us3MIV6LDmVpLgx1gS", "+78921234567", "Masha" }
                });

            migrationBuilder.InsertData(
                table: "ChatParticipants",
                columns: new[] { "ChatId", "UserId", "RoleId" },
                values: new object[,]
                {
                    { -1, -1, 1 },
                    { -2, -1, 2 },
                    { -1, -2, 2 },
                    { -2, -2, 1 },
                    { -1, -3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "FriendId", "UserId" },
                values: new object[,]
                {
                    { -1, -3 },
                    { -3, -1 },
                    { -2, -1 },
                    { -1, -2 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "CreationDate", "Data", "IsReaded", "SenderId" },
                values: new object[,]
                {
                    { -7, -1, new DateTime(2021, 12, 16, 13, 16, 30, 191, DateTimeKind.Local), "У меня вообще тройка, не стоит отчаиваться", true, -3 },
                    { -3, -1, new DateTime(2021, 12, 16, 13, 16, 14, 191, DateTimeKind.Local), "Отлично! Как у тебя?", true, -3 },
                    { -11, -2, new DateTime(2021, 12, 2, 20, 16, 11, 191, DateTimeKind.Local), "Good bye, World!", true, -2 },
                    { -2, -1, new DateTime(2021, 12, 16, 13, 16, 12, 191, DateTimeKind.Local), "Привет, нормально", true, -2 },
                    { -5, -1, new DateTime(2021, 12, 16, 13, 16, 20, 191, DateTimeKind.Local), "Что случилось?", true, -2 },
                    { -9, -1, new DateTime(2021, 12, 16, 13, 16, 36, 191, DateTimeKind.Local), "Приезжайте ко мне, будем в шашки играть", true, -3 },
                    { -10, -1, new DateTime(2021, 12, 16, 13, 16, 38, 191, DateTimeKind.Local), "Выезжаю...", false, -1 },
                    { -6, -1, new DateTime(2021, 12, 16, 13, 16, 25, 191, DateTimeKind.Local), "Получил 4 по алгебре", true, -1 },
                    { -4, -1, new DateTime(2021, 12, 16, 13, 16, 16, 191, DateTimeKind.Local), "Могло быть и лучше", true, -1 },
                    { -1, -1, new DateTime(2021, 12, 16, 13, 16, 10, 191, DateTimeKind.Local), "Привет, как у вас дела?", true, -1 },
                    { -8, -1, new DateTime(2021, 12, 16, 13, 16, 35, 191, DateTimeKind.Local), "Нормально все будет", true, -2 },
                    { -12, -2, new DateTime(2021, 12, 2, 21, 16, 11, 191, DateTimeKind.Local), "My life be like, uuuuaaaa", false, -3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitations_ChatId",
                table: "ChatInvitations",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitations_RecipientId",
                table: "ChatInvitations",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatInvitations_SenderId",
                table: "ChatInvitations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_RoleId",
                table: "ChatParticipants",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatParticipants_UserId",
                table: "ChatParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitations_RecipientId",
                table: "FriendInvitations",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendInvitations_SenderId",
                table: "FriendInvitations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                table: "Users",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatInvitations");

            migrationBuilder.DropTable(
                name: "ChatParticipants");

            migrationBuilder.DropTable(
                name: "FriendInvitations");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
