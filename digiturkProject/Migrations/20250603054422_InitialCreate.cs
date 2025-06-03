using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace digiturkProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternetPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageSrc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BaseTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Disclaimer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BadgeLeft = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BadgeRight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeaturesJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Time = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HomeTeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HomeTeamImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AwayTeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AwayTeamImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BuyLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BadgeLeft = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BadgeRight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FeaturesJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DetailLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeedOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DisplayText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstPrice = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InternetPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpeedOptions_InternetPackages_InternetPackageId",
                        column: x => x.InternetPackageId,
                        principalTable: "InternetPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpeedOptions_InternetPackageId",
                table: "SpeedOptions",
                column: "InternetPackageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "SpeedOptions");

            migrationBuilder.DropTable(
                name: "TvPackages");

            migrationBuilder.DropTable(
                name: "InternetPackages");
        }
    }
}
