using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoRedacaoPerguntaRespostaMapping : IEntityTypeConfiguration<AvaliacaoRedacaoPerguntaResposta>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoRedacaoPerguntaResposta> builder)
        {
            builder.ToTable("AvaliacaoRedacaoPerguntaRespostas");

            builder.Property(p => p.Valor).HasMaxLength(255).IsRequired();

            builder.HasOne(a => a.AvaliacaoRedacaoPergunta)
                .WithMany(arp => arp.AvaliacaoRedacaoPerguntaRespostas)
                .HasForeignKey(a => a.AvaliacaoRedacaoPerguntaId);
        }
    }
}
