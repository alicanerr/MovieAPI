using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmAPI.Persistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmYapimYil = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Film_Salon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GosterimYili = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Salon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Film_Salon_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Salon_Salons_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Salons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "FilmAd", "FilmYapimYil" },
                values: new object[,]
                {
                    { 1, "Interstellar", 2014 },
                    { 2, "Passangers", 2016 },
                    { 3, "Tenet", 2020 }
                });

            migrationBuilder.InsertData(
                table: "Salons",
                columns: new[] { "Id", "SalonAd" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" }
                });

            migrationBuilder.InsertData(
                table: "Film_Salon",
                columns: new[] { "Id", "FilmId", "GosterimYili", "SalonId" },
                values: new object[,]
                {
                    { 1, 1, 2014, 1 },
                    { 2, 1, 2014, 2 },
                    { 3, 1, 2015, 3 },
                    { 4, 2, 2016, 1 },
                    { 5, 3, 2020, 3 },
                    { 6, 3, 2020, 2 },
                    { 7, 3, 2020, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Film_Salon_FilmId",
                table: "Film_Salon",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Salon_SalonId",
                table: "Film_Salon",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film_Salon");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Salons");
        }
    }
}
