using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exame.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    DES_PRODUTO = table.Column<string>(type: "varchar(30)", nullable: true),
                    STA_STATUS = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_COSIF",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    ID_COSIF = table.Column<string>(type: "varchar(11)", nullable: false),
                    ID_CLASSIFICACAO = table.Column<string>(type: "char(6)", nullable: true),
                    STA_STATUS = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_COSIF", x => new { x.ID_PRODUTO, x.ID_COSIF });
                    table.ForeignKey(
                        name: "FK_PRODUTO_COSIF_PRODUTO_ID_PRODUTO",
                        column: x => x.ID_PRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTO_MANUAL",
                columns: table => new
                {
                    DAT_MES = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    DAT_ANO = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    NUM_LANCAMENTO = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ID_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    ID_COSIF = table.Column<string>(type: "varchar(11)", nullable: false),
                    DES_DESCRICAO = table.Column<string>(type: "varchar(50)", nullable: false),
                    DAT_MOVIMENTO = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ID_USUARIO = table.Column<string>(type: "varchar(15)", nullable: false),
                    VAL_VALOR = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTO_MANUAL", x => new { x.DAT_MES, x.DAT_ANO, x.NUM_LANCAMENTO, x.ID_PRODUTO, x.ID_COSIF });
                    table.ForeignKey(
                        name: "FK_MOVIMENTO_MANUAL_PRODUTO_COSIF_ID_PRODUTO_ID_COSIF",
                        columns: x => new { x.ID_PRODUTO, x.ID_COSIF },
                        principalTable: "PRODUTO_COSIF",
                        principalColumns: new[] { "ID_PRODUTO", "ID_COSIF" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTO_MANUAL_ID_PRODUTO_ID_COSIF",
                table: "MOVIMENTO_MANUAL",
                columns: new[] { "ID_PRODUTO", "ID_COSIF" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTO_MANUAL");

            migrationBuilder.DropTable(
                name: "PRODUTO_COSIF");

            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
