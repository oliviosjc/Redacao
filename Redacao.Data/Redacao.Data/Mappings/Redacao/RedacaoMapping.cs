using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Mappings.Redacao
{
    public class RedacaoMapping : IEntityTypeConfiguration<RedacaoRedacao>
    {
        public void Configure(EntityTypeBuilder<RedacaoRedacao> builder)
        {
            builder.ToTable("Redacoes");

            builder.Property(p => p.Descricao).HasMaxLength(255);

            builder.Property(p => p.TipoRedacao).IsRequired().HasMaxLength(8);

            builder.Property(p => p.StatusRedacao).IsRequired().HasMaxLength(8);

            builder.HasOne(r => r.TemaRedacao)
                .WithMany(tr => tr.Redacoes)
                .HasForeignKey(f => f.TemaRedacaoId)
                .HasConstraintName("FK__Redacao__TemaRedacao");

            builder.HasOne(r => r.Usuario)
                .WithMany(ua => ua.Redacoes)
                .HasForeignKey(f => f.UsuarioAlunoId)
                .HasConstraintName("FK__Redacao__UsuarioAluno");

            builder.HasOne(r => r.Usuario)
                .WithMany(ua => ua.Redacoes)
                .HasForeignKey(f => f.UsuarioProfessorId)
                .HasConstraintName("FK__Redacao__UsuarioProfessor");

            builder.HasOne(r => r.Organizacao)
                .WithMany(ua => ua.Redacoes)
                .HasForeignKey(f => f.OrganizacaoId)
                .HasConstraintName("FK__Redacao__Organizacao");
        }
    }
}
