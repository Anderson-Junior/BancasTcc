using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class DiasDisponiveisConfiguration : IEntityTypeConfiguration<DiasDisponiveis>
    {
        public void Configure(EntityTypeBuilder<DiasDisponiveis> builder)
        {
            builder.HasKey(d => d.DiasDisponiveisId);

            builder.HasOne(d => d.Usuario)
                   .WithMany(d => d.DiasDisponiveis)
                   .HasForeignKey(d => d.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
