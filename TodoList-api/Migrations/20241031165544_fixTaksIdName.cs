using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoList_api.Migrations
{
    /// <inheritdoc />
    public partial class fixTaksIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Tasks",
                newName: "TaskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Tasks",
                newName: "CityId");
        }
    }
}
