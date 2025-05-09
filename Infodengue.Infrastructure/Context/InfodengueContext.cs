using Microsoft.EntityFrameworkCore;
using Infodengue.Domain.Entities;

namespace Infodengue.Infrastructure.Context
{
    public class InfodengueContext : DbContext
    {
        public InfodengueContext(DbContextOptions<InfodengueContext> options)
            : base(options)
        {
        }

        public DbSet<Solicitante> Solicitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitante>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.HasIndex(s => s.CPF).IsUnique();
                entity.Property(s => s.Nome).IsRequired().HasMaxLength(100);
                entity.Property(s => s.CPF).IsRequired().HasMaxLength(11);
            });

            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Arbovirose).IsRequired();
                entity.Property(r => r.CodigoIbge).IsRequired();
                entity.Property(r => r.Municipio).IsRequired();
                entity.HasOne(r => r.Solicitante)
                      .WithMany(s => s.Relatorios)
                      .HasForeignKey(r => r.SolicitanteId);
            });
        }
    }
}
