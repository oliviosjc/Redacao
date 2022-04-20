using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoRedacaoRespostaAlunoMapping : IEntityTypeConfiguration<AvaliacaoRedacaoRespostaAluno>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoRedacaoRespostaAluno> builder)
        {
            builder.ToTable("AvaliacaoRedacaoRespostaAlunos");

            builder.Property(v => v.Resposta).HasMaxLength(255).IsRequired();

            builder.HasOne(v => v.Redacao)
                .WithMany(r => r.AvaliacaoRedacaoRespostaAlunos)
                .HasForeignKey(f => f.RedacaoId);

            builder.HasOne(v => v.AvaliacaoRedacaoPerguntaResposta)
                .WithMany(arpr => arpr.AvaliacaoRedacaoRespostaAlunos)
                .HasForeignKey(f => f.AvaliacaoRedacaoPerguntaRespostaId);
        }
    }
}
