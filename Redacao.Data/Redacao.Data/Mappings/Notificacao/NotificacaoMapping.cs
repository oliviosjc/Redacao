using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Notificacao
{
    public class NotificacaoMapping : IEntityTypeConfiguration<NotificacaoNotificacao>
    {
        public void Configure(EntityTypeBuilder<NotificacaoNotificacao> builder)
        {
            builder.ToTable("Notificacoes");

            builder.Property(p => p.Mensagem).IsRequired().HasMaxLength(255);

            builder.Property(p => p.TipoNotificacao).IsRequired();

            builder.Property(p => p.Visualizada).IsRequired().HasDefaultValue(false);

            builder.HasOne(n => n.Usuario)
                .WithMany(u => u.Notificacoes)
                .HasForeignKey(f => f.UsuarioId)
                .HasConstraintName("FK__Notificacao__Usuario");
        }
    }
}
