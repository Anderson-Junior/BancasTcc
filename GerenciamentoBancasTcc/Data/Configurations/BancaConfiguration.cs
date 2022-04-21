using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class BancaConfiguration : IEntityTypeConfiguration<Banca>
    {
        public void Configure(EntityTypeBuilder<Banca> builder)
        {
            builder.HasKey(x => x.BancaId);

            //builder.HasOne(x => x.Curso)
            //       .WithMany(x => x.Bancas)
            //       .HasForeignKey(x => x.CursoId)
            //       .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Turma)
                   .WithMany(x => x.Banca)
                   .HasForeignKey(x => x.TurmaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.Bancas)
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
