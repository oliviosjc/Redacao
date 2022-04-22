using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Suporte.Sugestao
{
    public class SugestaoMapping : IEntityTypeConfiguration<SugestaoSugestao>
    {
        public void Configure(EntityTypeBuilder<SugestaoSugestao> builder)
        {
            builder.ToTable("Sugestoes");

            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Tipo).IsRequired();

            builder.Property(p => p.Status).IsRequired();

            builder.Property(p => p.Resposta).HasMaxLength(255);
        }
    }
}
