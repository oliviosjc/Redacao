using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Vestibular
{
    public class VestibularTemaMapping : IEntityTypeConfiguration<VestibularTema>
    {
        public void Configure(EntityTypeBuilder<VestibularTema> builder)
        {
            builder.ToTable("VestibularesTemas");

            builder.HasOne(vt => vt.Tema)
                .WithMany(t => t.Vestibulares)
                .HasForeignKey(f => f.TemaId);

            builder.HasOne(vt => vt.Vestibular)
                .WithMany(v => v.Temas)
                .HasForeignKey(f => f.VestibularId);
        }
    }
}
