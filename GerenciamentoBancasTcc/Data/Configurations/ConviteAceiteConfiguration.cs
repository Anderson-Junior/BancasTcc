using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class ConviteAceiteConfiguration : IEntityTypeConfiguration<ConviteAceite>
    {
        public void Configure(EntityTypeBuilder<ConviteAceite> builder)
        {
            builder.HasKey(x => x.ConviteAceiteId);

            builder.HasOne(x => x.Convite)
                .WithMany(x => x.ConviteAceites)
                .HasForeignKey(x => x.ConviteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
