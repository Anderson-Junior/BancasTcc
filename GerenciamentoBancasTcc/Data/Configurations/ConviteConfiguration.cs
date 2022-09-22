using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class ConviteConfiguration : IEntityTypeConfiguration<Convite>
    {
        public void Configure(EntityTypeBuilder<Convite> builder)
        {
            builder.HasKey(x => x.ConviteId);

            builder.HasOne(x => x.Coordenador)
                .WithMany(x => x.ConvitesCoodenadores)
                .HasForeignKey(x => x.CoordenadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Professor)
               .WithOne(b => b.ConviteProfessor)
               .HasForeignKey<Convite>(b => b.ProfessorId);
        }
    }
}
