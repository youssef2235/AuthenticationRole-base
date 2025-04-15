using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationRole_base.Migrations
{
    /// <inheritdoc />
    public partial class fullnome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChemicalAnalysis");

            migrationBuilder.DropTable(
                name: "PhysicalAnalysis");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pH = table.Column<double>(type: "float", nullable: true),
                    ElectricalConductivity = table.Column<double>(type: "float", nullable: true),
                    OrganicMatter = table.Column<double>(type: "float", nullable: true),
                    TotalNitrogen = table.Column<double>(type: "float", nullable: true),
                    AvailablePhosphorus = table.Column<double>(type: "float", nullable: true),
                    ExchangePotassium = table.Column<double>(type: "float", nullable: true),
                    Calcium = table.Column<double>(type: "float", nullable: true),
                    Magnesium = table.Column<double>(type: "float", nullable: true),
                    Iron = table.Column<double>(type: "float", nullable: true),
                    Zinc = table.Column<double>(type: "float", nullable: true),
                    SandPercentage = table.Column<double>(type: "float", nullable: true),
                    ClayPercentage = table.Column<double>(type: "float", nullable: true),
                    SiltPercentage = table.Column<double>(type: "float", nullable: true),
                    ApparentDensity = table.Column<double>(type: "float", nullable: true),
                    Problems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChemicalAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Assessment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxValue = table.Column<double>(type: "float", nullable: false),
                    MinValue = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChemicalAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChemicalAnalysis_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalAnalysis_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChemicalAnalysis_ReportId",
                table: "ChemicalAnalysis",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalAnalysis_ReportId",
                table: "PhysicalAnalysis",
                column: "ReportId");
        }
    }
}
