using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{

    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.HasKey(a => a.EquipeId);

            builder.HasOne(x => x.Banca)
                   .WithMany(x => x.Equipes)
                   .HasForeignKey(x => x.BancaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
