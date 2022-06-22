using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GerenciamentoBancasTcc.Data.Configurations
{

    public class ArquivoConfiguration : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(x => x.ArquivosId);

            builder.HasOne(x => x.Banca)
                    .WithMany(x => x.Arquivos)
                    .HasForeignKey(x => x.BancaId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
