using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeForeignKeyRequiredForTableUserInteraction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskRequesterId",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks",
                column: "TaskRequesterId",
                principalTable: "TaskUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks");

            migrationBuilder.AlterColumn<int>(
                name: "TaskRequesterId",
                table: "TodoTasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTasks_TaskUsers_TaskRequesterId",
                table: "TodoTasks",
                column: "TaskRequesterId",
                principalTable: "TaskUsers",
                principalColumn: "Id");
        }
    }
}
