using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Redacao
{
    public class TemaRedacaoMapping : IEntityTypeConfiguration<TemaRedacao>
    {
        public void Configure(EntityTypeBuilder<TemaRedacao> builder)
        {
            builder.ToTable("TemasRedacao");

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(255);

            builder.HasOne(tr => tr.Organizacao)
                .WithMany(or => or.TemasRedacao)
                .HasForeignKey(f => f.OrganizacaoId)
                .HasConstraintName("FK__TemaRedacao__Organizacao");

            builder.HasOne(tr => tr.Vestibular)
                .WithMany(v => v.TemasRedacao)
                .HasForeignKey(f => f.VestibularId)
                .HasConstraintName("FK__TemaRedacao__Vestibular");
        }
    }
}
