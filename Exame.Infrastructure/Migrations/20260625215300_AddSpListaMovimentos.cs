using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exame.Infrastructure.Migrations
{
    public partial class AddSpListaMovimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE SP_LISTA_MOVIMENTOS
                AS
                BEGIN
                    SET NOCOUNT ON;

                    SELECT
                        MM.DAT_MES            AS MES,
                        MM.DAT_ANO            AS ANO,
                        MM.ID_PRODUTO         AS ID_PRODUTO,
                        P.DES_PRODUTO         AS DESCRICAO_PRODUTO,
                        MM.NUM_LANCAMENTO     AS NUMERO_LANCAMENTO,
                        MM.DES_DESCRICAO      AS DESCRICAO,
                        MM.VAL_VALOR          AS VALOR
                    FROM MOVIMENTO_MANUAL MM
                    INNER JOIN PRODUTO P
                        ON P.ID_PRODUTO = MM.ID_PRODUTO
                    ORDER BY
                        MM.DAT_MES,
                        MM.DAT_ANO,
                        MM.NUM_LANCAMENTO;
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE SP_LISTA_MOVIMENTOS;");
        }
    }
}