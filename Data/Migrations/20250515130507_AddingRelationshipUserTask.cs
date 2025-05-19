using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingRelationshipUserTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskRequesterId",
                table: "TodoTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_TaskRequesterId",
                table: "TodoTasks",
                column: "TaskRequesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks",
                column: "TaskRequesterId",
                principalTable: "TaskUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_TaskRequesterId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "TaskRequesterId",
                table: "TodoTasks");
        }
    }
}
