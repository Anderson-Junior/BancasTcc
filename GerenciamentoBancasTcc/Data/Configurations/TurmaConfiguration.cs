using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(x => x.TurmaId);

            builder.HasOne(x => x.Curso)
                   .WithMany(x => x.Turmas)
                   .HasForeignKey(x => x.CursoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
