using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoRedacaoPerguntaMapping : IEntityTypeConfiguration<AvaliacaoRedacaoPergunta>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoRedacaoPergunta> builder)
        {
            builder.ToTable("AvaliacaoRedacaoPerguntas");

            builder.Property(p => p.TipoRedacao).IsRequired();

            builder.Property(p => p.Titulo).HasMaxLength(255).IsRequired();

            builder.Property(p => p.EObrigatoria).IsRequired();

            builder.Property(p => p.TipoPergunta).IsRequired();
        }
    }
}
