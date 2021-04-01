using Microsoft.EntityFrameworkCore.Migrations;

namespace Domen.Migrations
{
    public partial class addedclassbetweenDobavljacandProizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DobavljacProizvod");

            migrationBuilder.CreateTable(
                name: "ProizvodDobavljac",
                columns: table => new
                {
                    ProizvodId = table.Column<long>(type: "bigint", nullable: false),
                    DobavljacId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodDobavljac", x => new { x.DobavljacId, x.ProizvodId });
                    table.ForeignKey(
                        name: "FK_ProizvodDobavljac_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodDobavljac_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodDobavljac_ProizvodId",
                table: "ProizvodDobavljac",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodDobavljac");

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
        }
    }
}
