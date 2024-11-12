using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    channelCode = table.Column<int>(type: "int", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    emailChannel = table.Column<bool>(type: "bit", nullable: false),
                    smsChannel = table.Column<bool>(type: "bit", nullable: false),
                    pushChannel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "channelCode", "date", "message", "orderId", "userId" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2024, 12, 1), "EMAIL kanalından mesaj gönderildi", 1, 1 },
                    { 2, 1, new DateOnly(2024, 12, 1), "EMAIL kanalından mesaj gönderildi", 2, 1 },
                    { 3, 2, new DateOnly(2024, 12, 1), "SMS kanalından mesaj gönderildi", 2, 1 },
                    { 4, 1, new DateOnly(2024, 12, 1), "EMAIL kanalından mesaj gönderildi", 3, 2 },
                    { 5, 3, new DateOnly(2024, 12, 1), "PUSH kanalından mesaj gönderildi", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "id", "amount", "date", "day", "emailChannel", "pushChannel", "smsChannel", "status", "userId" },
                values: new object[,]
                {
                    { 1, 500m, new DateOnly(2024, 12, 1), 1, true, false, false, 1, 1 },
                    { 2, 99999m, new DateOnly(2024, 12, 1), 28, true, false, true, 0, 1 },
                    { 3, 5000m, new DateOnly(2024, 12, 1), 1, true, false, false, 0, 2 },
                    { 4, 500m, new DateOnly(2024, 12, 1), 28, false, true, false, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "name", "userRole" },
                values: new object[,]
                {
                    { 1, "Musa", 1 },
                    { 2, "Erhan", 1 },
                    { 3, "Hilal", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
