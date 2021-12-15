using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoMessenger.Migrations
{
    public partial class ChatParttestdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
