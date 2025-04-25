using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlueGreenEG.Migrations
{
    /// <inheritdoc />
    public partial class updateforphonenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNamber",
                table: "FormContact",
                newName: "PhoneNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "FormContact",
                newName: "PhoneNamber");
        }
    }
}
