using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingRequesterColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskRequester",
                table: "TodoTasks");

            migrationBuilder.CreateTable(
                name: "TaskUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUsers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskUsers");

            migrationBuilder.AddColumn<string>(
                name: "TaskRequester",
                table: "TodoTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
