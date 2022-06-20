
using Microsoft.EntityFrameworkCore;
using Projeto.Model;

namespace Projeto.Banco
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {
        }

        public DbSet<Estoque> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var produto = modelBuilder.Entity<Estoque>();
            produto.ToTable("tb_estoque");
            produto.HasKey(x => x.Id);
            produto.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            produto.Property(x => x.Nome).HasColumnName("Nome").IsRequired();
            produto.Property(x => x.DTEntrada).HasColumnName("Data_de_Entrada");
        }

    }
}