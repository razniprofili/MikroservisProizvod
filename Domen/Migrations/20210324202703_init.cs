using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dobavljac",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipProizvoda",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipProizvoda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Pdv = table.Column<double>(type: "float", nullable: false),
                    TipProizvodaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvod_TipProizvoda_TipProizvodaId",
                        column: x => x.TipProizvodaId,
                        principalTable: "TipProizvoda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DobavljacProizvod",
                columns: table => new
                {
                    DobavljaciId = table.Column<long>(type: "bigint", nullable: false),
                    ProizvodiId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobavljacProizvod", x => new { x.DobavljaciId, x.ProizvodiId });
                    table.ForeignKey(
                        name: "FK_DobavljacProizvod_Dobavljac_DobavljaciId",
                        column: x => x.DobavljaciId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobavljacProizvod_Proizvod_ProizvodiId",
                        column: x => x.ProizvodiId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacProizvod_ProizvodiId",
                table: "DobavljacProizvod",
                column: "ProizvodiId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_TipProizvodaId",
                table: "Proizvod",
                column: "TipProizvodaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DobavljacProizvod");

            migrationBuilder.DropTable(
                name: "Dobavljac");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "TipProizvoda");
        }
    }
}
