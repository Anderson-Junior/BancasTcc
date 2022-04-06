using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class AlunosBancasConfiguration : IEntityTypeConfiguration<AlunosBancas>
    {
        public void Configure(EntityTypeBuilder<AlunosBancas> builder)
        {
            builder.HasKey(x => new { x.AlunoId, x.BancaId });

            builder.HasOne(c => c.Aluno)
                   .WithMany(c => c.AlunosBancas)
                   .HasForeignKey(c => c.AlunoId);

            builder.HasOne(c => c.Banca)
                   .WithMany(c => c.AlunosBancas)
                   .HasForeignKey(c => c.BancaId);
        }
    }
}
