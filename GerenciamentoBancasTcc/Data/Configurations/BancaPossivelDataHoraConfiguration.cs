using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class BancaPossivelDataHoraConfiguration : IEntityTypeConfiguration<BancaPossivelDataHora>
    {
        public void Configure(EntityTypeBuilder<BancaPossivelDataHora> builder)
        {
            builder.HasKey(x => x.BancaPossivelDataHoraId);

            builder.HasOne(x => x.Banca)
                   .WithMany(x => x.BancaPossiveisDataHora)
                   .HasForeignKey(x => x.BancaId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
