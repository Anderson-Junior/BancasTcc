using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{

    public class CursosUsuariosConfiguration : IEntityTypeConfiguration<CursosUsuarios>
    {
        public void Configure(EntityTypeBuilder<CursosUsuarios> builder)
        {
            builder.HasKey(ca => new { ca.CursoId, ca.UsuarioId });

            builder.HasOne(c => c.Cursos)
                   .WithMany(c => c.CursosUsuarios)
                   .HasForeignKey(c => c.CursoId);

            builder.HasOne(c => c.Usuarios)
                   .WithMany(c => c.CursosUsuarios)
                   .HasForeignKey(c => c.UsuarioId);
        }
    }
}
