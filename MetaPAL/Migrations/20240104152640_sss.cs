using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScanId",
                table: "SpectrumMatch",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MsDataScan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScanNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    SpectrumRepresentation = table.Column<int>(type: "INTEGER", nullable: false),
                    MassSpectrumType = table.Column<int>(type: "INTEGER", nullable: false),
                    MsLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    MassAnalyzerType = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanPolarity = table.Column<int>(type: "INTEGER", nullable: false),
                    ScanStartTime = table.Column<float>(type: "REAL", nullable: true),
                    ScanWindowUpperLimit = table.Column<float>(type: "REAL", nullable: true),
                    ScanWindowLowerLimit = table.Column<float>(type: "REAL", nullable: true),
                    FilterString = table.Column<string>(type: "TEXT", nullable: true),
                    TotalIonCurrent = table.Column<float>(type: "REAL", nullable: true),
                    IonInjectionTime = table.Column<float>(type: "REAL", nullable: true),
                    PrecursorScanNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    SelectedIonMz = table.Column<float>(type: "REAL", nullable: true),
                    ExperimentalPrecursorMonoisotopicMz = table.Column<float>(type: "REAL", nullable: true),
                    IsolationWindowTargetMz = table.Column<float>(type: "REAL", nullable: true),
                    IsolationWindowLowerOffset = table.Column<float>(type: "REAL", nullable: true),
                    IsolationWindowUpperOffset = table.Column<float>(type: "REAL", nullable: true),
                    DissociationMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    NormalizedCollisionEnergy = table.Column<float>(type: "REAL", nullable: true),
                    SelectedIonChargeStateGuess = table.Column<int>(type: "INTEGER", nullable: true),
                    SelectedIonIntensity = table.Column<float>(type: "REAL", nullable: true),
                    NativeId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsDataScan", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MsDataScan");

            migrationBuilder.DropColumn(
                name: "ScanId",
                table: "SpectrumMatch");
        }
    }
}
