using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaucyBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamEntityID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamEntityDiscordID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    TeamEntityName = table.Column<string>(type: "TEXT", nullable: true),
                    TeamEntityGuildID = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamEntityID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketEntityID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TicketEntityLabelID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    TeamEntityID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    TicketEntityState = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketEntityChannelID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    TicketEntityOpenTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TicketEntityCloseTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketEntityID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    SaucyUserEntityID = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscordID = table.Column<ulong>(type: "INTEGER", nullable: false),
                    GuildID = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.SaucyUserEntityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
