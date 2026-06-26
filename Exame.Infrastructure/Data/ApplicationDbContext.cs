using Exame.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exame.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<ProdutoCosif> ProdutoCosifs => Set<ProdutoCosif>();
    public DbSet<MovimentoManual> MovimentosManuais => Set<MovimentoManual>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}