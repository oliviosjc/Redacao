using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoCorrecaoPerguntaRespostaMapping : IEntityTypeConfiguration<AvaliacaoCorrecaoPerguntaResposta>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoCorrecaoPerguntaResposta> builder)
        {
            builder.ToTable("AvaliacaoCorrecaoPerguntaRespostas");

            builder.Property(p => p.Valor).HasMaxLength(255).IsRequired();

            builder.HasOne(a => a.AvaliacaoCorrecaoPergunta)
                .WithMany(acp => acp.AvaliacaoCorrecaoPerguntaRespostas)
                .HasForeignKey(f => f.AvaliacaoCorrecaoPerguntaId);

        }
    }
}
