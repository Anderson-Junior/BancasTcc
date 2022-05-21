//using GerenciamentoBancasTcc.Domains.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace GerenciamentoBancasTcc.Data.Configurations
//{
//    public class ConviteUsuarioConfiguration : IEntityTypeConfiguration<ConviteUsuario>
//    {
//        public void Configure(EntityTypeBuilder<ConviteUsuario> builder)
//        {
//            builder.HasKey(x => new { x.ConviteId, x.UsuarioId });

//            builder.HasOne(c => c.Convite)
//                   .WithMany(c => c.ConvitesUsuarios)
//                   .HasForeignKey(c => c.ConviteId);

//            builder.HasOne(c => c.Usuario)
//                   .WithMany(c => c.ConvitesUsuarios)
//                   .HasForeignKey(c => c.UsuarioId);
//        }
//    }
//}
