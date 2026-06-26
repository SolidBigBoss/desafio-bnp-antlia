using Exame.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exame.Infrastructure.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("PRODUTO");

        builder.HasKey(p => p.IdProduto);

        builder.Property(p => p.IdProduto)
            .HasColumnName("ID_PRODUTO")
            .HasColumnType("char(4)")
            .IsRequired();

        builder.Property(p => p.DesProduto)
            .HasColumnName("DES_PRODUTO")
            .HasColumnType("varchar(30)");

        builder.Property(p => p.StaStatus)
            .HasColumnName("STA_STATUS")
            .HasColumnType("char(1)");
    }
}