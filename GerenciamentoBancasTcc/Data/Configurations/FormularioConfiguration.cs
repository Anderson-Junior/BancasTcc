using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{

    public class FormularioConfiguration : IEntityTypeConfiguration<Formulario>
    {
        public void Configure(EntityTypeBuilder<Formulario> builder)
        {
            builder.HasKey(a => a.FormularioId);

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.Formularios)
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Curso)
                   .WithMany(x => x.Formularios)
                   .HasForeignKey(x => x.CursoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
