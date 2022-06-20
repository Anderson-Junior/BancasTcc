using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GerenciamentoBancasTcc.Data.Configurations
{

    public class ArquivoConfiguration : IEntityTypeConfiguration<Arquivos>
    {
        public void Configure(EntityTypeBuilder<Arquivos> builder)
        {
            builder.HasKey(x => x.ArquivosId);

            //builder.HasOne(x => x.Banca)
            //        .WithOne(x => x.Arquivos)
            //        .HasForeignKey<Banca>(b => b.BancaId);
        }
    }
}
