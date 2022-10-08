﻿using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoBancasTcc.Data.Configurations
{
    public class ConviteConfiguration : IEntityTypeConfiguration<Convite>
    {
        public void Configure(EntityTypeBuilder<Convite> builder)
        {
            builder.HasKey(x => x.ConviteId);

            builder.HasOne(x => x.Banca)
                .WithMany(x => x.Convites)
                .HasForeignKey(x => x.BancaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Professor)
               .WithOne(b => b.ConviteProfessor)
               .HasForeignKey<Convite>(b => b.ProfessorId);
        }
    }
}
