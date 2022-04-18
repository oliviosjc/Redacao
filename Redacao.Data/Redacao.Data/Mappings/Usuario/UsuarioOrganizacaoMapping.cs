using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Usuario
{
    public class UsuarioOrganizacaoMapping : IEntityTypeConfiguration<UsuarioOrganizacao>
    {
        public void Configure(EntityTypeBuilder<UsuarioOrganizacao> builder)
        {
            builder.ToTable("UsuarioOrganizacoes");

            builder.HasKey(key => new { key.UsuarioId, key.OrganizacaoId });

            builder.HasOne(uo => uo.Usuario)
                .WithMany(u => u.Organizacoes)
                .HasForeignKey(uo => uo.UsuarioId);


            builder.HasOne(uo => uo.Organizacao)
                .WithMany(o => o.Usuarios)
                .HasForeignKey(f => f.OrganizacaoId);
        }
    }
}
