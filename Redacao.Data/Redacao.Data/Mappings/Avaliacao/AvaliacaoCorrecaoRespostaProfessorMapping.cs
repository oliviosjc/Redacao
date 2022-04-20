using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Avaliacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Avaliacao
{
    public class AvaliacaoCorrecaoRespostaProfessorMapping : IEntityTypeConfiguration<AvaliacaoCorrecaoRespostaProfessor>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoCorrecaoRespostaProfessor> builder)
        {
            builder.ToTable("AvaliacaoCorrecaoRespostaProfessores");

            builder.Property(p => p.Resposta).HasMaxLength(255).IsRequired();

            builder.HasOne(a => a.Redacao)
                .WithMany(r => r.AvaliacaoCorrecaoRespostaProfessores)
                .HasForeignKey(f => f.RedacaoId);

            builder.HasOne(a => a.AvaliacaoCorrecaoPerguntaResposta)
                .WithMany(acpr => acpr.AvaliacaoCorrecaoRespostaProfessores)
                .HasForeignKey(a => a.AvaliacaoCorrecaoPerguntaRespostaId);
        }
    }
}
