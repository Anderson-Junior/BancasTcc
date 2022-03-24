using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.AlunoId);

            builder.HasOne(e => e.Equipe)
                   .WithMany(e => e.Alunos)
                   .HasForeignKey(x => x.EquipeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
