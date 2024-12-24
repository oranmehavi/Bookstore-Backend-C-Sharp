using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore_Backend_C_.Migrations
{
    /// <inheritdoc />
    public partial class changedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Books",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "BookName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Books",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BookName",
                table: "Books",
                newName: "Description");
        }
    }
}
