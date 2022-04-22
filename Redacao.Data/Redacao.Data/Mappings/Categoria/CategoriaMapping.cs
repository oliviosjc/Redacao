using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Categoria
{
    public class CategoriaMapping : IEntityTypeConfiguration<CategoriaCategoria>
    {
        public void Configure(EntityTypeBuilder<CategoriaCategoria> builder)
        {
            builder.ToTable("Categorias");

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);

            builder.Property(p => p.TipoCategoria).IsRequired();
        }
    }
}
