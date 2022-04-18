using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Organizacao
{
    public class OrganizacaoMapping : IEntityTypeConfiguration<OrganizacaoOrganizacao>
    {
        public void Configure(EntityTypeBuilder<OrganizacaoOrganizacao> builder)
        {
            builder.ToTable("Organizacoes");

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(255);

            builder.Property(p => p.CorPrimaria).IsRequired().HasMaxLength(8);

            builder.Property(p => p.CorSecundaria).IsRequired().HasMaxLength(8);

            builder.Property(p => p.TipoOrganizacao).IsRequired().HasMaxLength(2);
        }
    }
}
