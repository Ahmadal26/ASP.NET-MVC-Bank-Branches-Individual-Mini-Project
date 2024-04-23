using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", nullable: false),
                    LocationURL = table.Column<string>(type: "TEXT", nullable: false),
                    BranchManager = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BankBranches",
                columns: new[] { "Id", "BranchManager", "EmployeeCount", "LocationName", "LocationURL" },
                values: new object[] { 1, "Ali Mansor", 20, "KFH Auto", "https://maps.app.goo.gl/cqEbKLSB8p88RLaP7" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankBranches");
        }
    }
}
