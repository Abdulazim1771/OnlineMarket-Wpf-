using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMarketSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Renamedcolumnnameinproducttable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeltedAt",
                table: "Products",
                newName: "DeletedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Products",
                newName: "DeltedAt");
        }
    }
}
