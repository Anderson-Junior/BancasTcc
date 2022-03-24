using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class BancaConfiguration : IEntityTypeConfiguration<Banca>
    {
        public void Configure(EntityTypeBuilder<Banca> builder)
        {
            builder.HasKey(x => x.BancaId);
        }
    }
}
