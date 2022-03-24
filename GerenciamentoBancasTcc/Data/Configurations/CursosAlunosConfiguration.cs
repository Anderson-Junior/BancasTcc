using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class CursosAlunosConfiguration : IEntityTypeConfiguration<CursosAlunos>
    {
        public void Configure(EntityTypeBuilder<CursosAlunos> builder)
        {
            builder.HasKey(ca => new { ca.CursoId, ca.AlunoId });

            builder.HasOne(c => c.Cursos)
                   .WithMany(c => c.CursosAlunos)
                   .HasForeignKey(c => c.CursoId);

            builder.HasOne(c => c.Alunos)
                   .WithMany(c => c.CursosAlunos)
                   .HasForeignKey(c => c.AlunoId);
        }
    }
}
