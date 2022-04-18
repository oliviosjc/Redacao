using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Vestibular
{
    public class VestibularMapping : IEntityTypeConfiguration<VestibularVestibular>
    {
        public void Configure(EntityTypeBuilder<VestibularVestibular> builder)
        {
            builder.ToTable("Vestibulares");

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);

            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(255);

            builder.HasOne(v => v.Organizacao)
                .WithMany(or => or.Vestibulares)
                .HasForeignKey(f => f.OrganizacaoId)
                .HasConstraintName("FK__Vestibular__Organizacao");
        }
    }
}
