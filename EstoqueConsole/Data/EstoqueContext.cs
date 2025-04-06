using Microsoft.EntityFrameworkCore;
using EstoqueConsole.Models;

namespace EstoqueConsole.Data
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacaos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=estoque.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movimentacao>()
                .Property(m => m.Tipo)
                .HasConversion<string>();
        }
    }

}
