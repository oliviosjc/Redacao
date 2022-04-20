using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoCorrecaoPerguntaMapping : IEntityTypeConfiguration<AvaliacaoCorrecaoPergunta>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoCorrecaoPergunta> builder)
        {
            builder.ToTable("AvaliacaoCorrecaoPerguntas");

            builder.Property(p => p.TipoRedacao).IsRequired();

            builder.Property(p => p.EObrigatoria).IsRequired();

            builder.Property(p => p.Titulo).HasMaxLength(255).IsRequired();

            builder.Property(p => p.TipoPergunta).IsRequired();
        }
    }
}
