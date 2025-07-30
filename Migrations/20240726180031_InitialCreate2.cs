using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace user_task_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCreated",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeleted",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUpdated",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCreated",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataDeleted",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataUpdated",
                table: "Usuarios");
        }
    }
}
