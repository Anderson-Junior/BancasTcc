using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class FilialConfiguration : IEntityTypeConfiguration<Filial>
    {
        public void Configure(EntityTypeBuilder<Filial> builder)
        {
            builder.HasKey(a => a.FilialId);

            builder.HasOne(f => f.Instituicao)
                   .WithMany(f => f.Filiais)
                   .HasForeignKey(f => f.InstituicaoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
