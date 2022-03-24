using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class UsuariosBancaConfigurations : IEntityTypeConfiguration<UsuarioBanca>
    {
        public void Configure(EntityTypeBuilder<UsuarioBanca> builder)
        {
            builder.HasKey(ub => new { ub.UsuarioId, ub.BancaId });

            builder.HasOne(ub => ub.Usuarios)
                   .WithMany(c => c.UsuariosBancas)
                   .HasForeignKey(c => c.UsuarioId);

            builder.HasOne(ub => ub.Bancas)
                   .WithMany(ub => ub.UsuariosBancas)
                   .HasForeignKey(ub => ub.BancaId);
        }
    }
}
