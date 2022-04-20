﻿using Microsoft.EntityFrameworkCore;
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

            builder.Property(p => p.NomeOriginal).IsRequired().HasMaxLength(255);

            builder.Property(p => p.NomeInternoAzure).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Extensao).IsRequired().HasMaxLength(8);

            builder.Property(p => p.Tamanho).IsRequired().HasMaxLength(8);

            builder.HasOne(d => d.Redacao)
                .WithMany(r => r.DocumentosRedacao)
                .HasForeignKey(f => f.RedacaoId)
                .HasConstraintName("FK__Documento__Redacao");

            builder.HasOne(d => d.Tema)
                .WithMany(r => r.DocumentosTema)
                .HasForeignKey(f => f.TemaId)
                .HasConstraintName("FK__Documento__Tema");
        }
    }
}
