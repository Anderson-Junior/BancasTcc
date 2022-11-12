using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class DiaQueDeveOcorrerBancaConfiguration : IEntityTypeConfiguration<DiaQueDeveOcorrerBanca>
    {
        public void Configure(EntityTypeBuilder<DiaQueDeveOcorrerBanca> builder)
        {
            builder.HasKey(x => x.DiaQueDeveOcorrerBancaId);

            builder.HasOne(x => x.Banca)
                   .WithMany(x => x.DiaQueDeveOcorrerBancas)
                   .HasForeignKey(x => x.BancaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Convite)
                   .WithMany(x => x.DiaQueDeveOcorrerBancas)
                   .HasForeignKey(x => x.ConviteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
