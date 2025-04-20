using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationRole_base.Migrations
{
    /// <inheritdoc />
    public partial class contents201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content2",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content3",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content4",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content2",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Content3",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Content4",
                table: "Articles");
        }
    }
}
