using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class TestingConnectionAddedFilePathRevert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "SpectrumMatch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "SpectrumMatch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
