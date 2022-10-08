using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class QuestaoConfiguration : IEntityTypeConfiguration<Questao>
    {
        public void Configure(EntityTypeBuilder<Questao> builder)
        {
            builder.HasKey(a => a.QuestaoId);

            builder.HasOne(x => x.Formulario)
                   .WithMany(x => x.Questoes)
                   .HasForeignKey(x => x.FormularioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TipoQuestao)
                   .WithMany(x => x.Questoes)
                   .HasForeignKey(x => x.TipoQuestaoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
