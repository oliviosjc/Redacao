using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Documento
{
    public class DocumentoMapping : IEntityTypeConfiguration<DocumentoDocumento>
    {
        public void Configure(EntityTypeBuilder<DocumentoDocumento> builder)
        {
            builder.ToTable("Documentos");

            builder.HasIndex(i => i.ChaveValor);

            builder.HasIndex(i => i.Tipo);

            builder.Property(p => p.NomeOriginal).IsRequired().HasMaxLength(255);

            builder.Property(p => p.NomeInternoAzure).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Extensao).IsRequired().HasMaxLength(8);

            builder.Property(p => p.Tamanho).IsRequired().HasMaxLength(8);

            builder.Property(p => p.ChaveValor).IsRequired().HasMaxLength(8);

            builder.Property(p => p.Tipo).IsRequired();
        }
    }
}
