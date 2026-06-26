using Exame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exame.Infrastructure.Data.Configurations;

public class MovimentoManualConfiguration : IEntityTypeConfiguration<MovimentoManual>
{
    public void Configure(EntityTypeBuilder<MovimentoManual> builder)
    {
        builder.ToTable("MOVIMENTO_MANUAL");

        builder.HasKey(m => new { m.DatMes, m.DatAno, m.NumLancamento, m.IdProduto, m.IdCosif });

        builder.Property(m => m.DatMes)
            .HasColumnName("DAT_MES")
            .HasColumnType("numeric(2,0)");

        builder.Property(m => m.DatAno)
            .HasColumnName("DAT_ANO")
            .HasColumnType("numeric(4,0)");

        builder.Property(m => m.NumLancamento)
            .HasColumnName("NUM_LANCAMENTO")
            .HasColumnType("numeric(18,0)");

        builder.Property(m => m.IdProduto)
            .HasColumnName("ID_PRODUTO")
            .HasColumnType("char(4)")
            .IsRequired();

        builder.Property(m => m.IdCosif)
            .HasColumnName("ID_COSIF")
            .HasColumnType("varchar(11)")
            .IsRequired();

        builder.Property(m => m.DesDescricao)
            .HasColumnName("DES_DESCRICAO")
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(m => m.DatMovimento)
            .HasColumnName("DAT_MOVIMENTO")
            .HasColumnType("smalldatetime")
            .IsRequired();

        builder.Property(m => m.IdUsuario)
            .HasColumnName("ID_USUARIO")
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder.Property(m => m.ValValor)
            .HasColumnName("VAL_VALOR")
            .HasColumnType("numeric(18,2)")
            .IsRequired();

        builder.HasOne(m => m.ProdutoCosif)
            .WithMany(pc => pc.MovimentosManuais)
            .HasForeignKey(m => new { m.IdProduto, m.IdCosif });
    }
}