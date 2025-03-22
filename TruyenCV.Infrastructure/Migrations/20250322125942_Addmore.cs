using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TruyenCV.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addmore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Stories",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Stories");
        }
    }
}
