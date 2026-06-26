using Exame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exame.Infrastructure.Data.Configurations;

public class ProdutoCosifConfiguration : IEntityTypeConfiguration<ProdutoCosif>
{
    public void Configure(EntityTypeBuilder<ProdutoCosif> builder)
    {
        builder.ToTable("PRODUTO_COSIF");

        builder.HasKey(pc => new { pc.IdProduto, pc.IdCosif });

        builder.Property(pc => pc.IdProduto)
            .HasColumnName("ID_PRODUTO")
            .HasColumnType("char(4)")
            .IsRequired();

        builder.Property(pc => pc.IdCosif)
            .HasColumnName("ID_COSIF")
            .HasColumnType("varchar(11)")
            .IsRequired();

        builder.Property(pc => pc.IdClassificacao)
            .HasColumnName("ID_CLASSIFICACAO")
            .HasColumnType("char(6)");

        builder.Property(pc => pc.StaStatus)
            .HasColumnName("STA_STATUS")
            .HasColumnType("char(1)");

        builder.HasOne(pc => pc.Produto)
            .WithMany(p => p.ProdutoCosifs)
            .HasForeignKey(pc => pc.IdProduto);
    }
}