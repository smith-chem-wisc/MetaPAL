using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    public partial class TestingConnectionAddedFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "SpectrumMatch",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "SpectrumMatch");
        }
    }
}
