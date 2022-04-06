using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(a => a.CursoId);

            builder.HasOne(c => c.Filial)
                   .WithMany(c => c.Cursos)
                   .HasForeignKey(c => c.FilialId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
