using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Redacao.Data.Mappings.Avaliacao;
using Redacao.Data.Mappings.Documento;
using Redacao.Data.Mappings.Notificacao;
using Redacao.Data.Mappings.Organizacao;
using Redacao.Data.Mappings.Redacao;
using Redacao.Data.Mappings.Usuario;
using Redacao.Data.Mappings.Vestibular;
using Redacao.Domain.Entidades.Avaliacao;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Notificacao;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Data.Context
{
    public class RedacaoSQLContext : IdentityDbContext<UsuarioUsuario,
                                                    Role,
                                                    int,
                                                    UsuarioClaim,
                                                    UsuarioRole,
                                                    UsuarioLogin,
                                                    RoleClaim,
                                                    UsuarioToken>
    {
        public RedacaoSQLContext(DbContextOptions<RedacaoSQLContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DocumentoMapping());
            builder.ApplyConfiguration(new OrganizacaoMapping());
            builder.ApplyConfiguration(new RedacaoMapping());
            builder.ApplyConfiguration(new TemaRedacaoMapping());
            builder.ApplyConfiguration(new VestibularMapping());
            builder.ApplyConfiguration(new UsuarioOrganizacaoMapping());
            builder.ApplyConfiguration(new VestibularTemaMapping());
            builder.ApplyConfiguration(new AvaliacaoCorrecaoPerguntaMapping());
            builder.ApplyConfiguration(new AvaliacaoCorrecaoPerguntaRespostaMapping());
            builder.ApplyConfiguration(new AvaliacaoCorrecaoRespostaProfessorMapping());
            builder.ApplyConfiguration(new AvaliacaoRedacaoPerguntaMapping());
            builder.ApplyConfiguration(new AvaliacaoRedacaoPerguntaRespostaMapping());
            builder.ApplyConfiguration(new AvaliacaoRedacaoRespostaAlunoMapping());
            builder.ApplyConfiguration(new NotificacaoMapping());
            
            base.OnModelCreating(builder);
        }

        public virtual DbSet<AvaliacaoCorrecaoPergunta> AvaliacaoCorrecaoPerguntas { get; set; }
        public virtual DbSet<AvaliacaoCorrecaoPerguntaResposta> AvaliacaoCorrecaoPerguntaRespostas { get; set; }
        public virtual DbSet<AvaliacaoCorrecaoRespostaProfessor> AvaliacaoCorrecaoRespostaProfessores { get; set; }
        public virtual DbSet<AvaliacaoRedacaoPergunta> AvaliacaoRedacaoPerguntas { get; set; }
        public virtual DbSet<AvaliacaoRedacaoPerguntaResposta> AvaliacaoRedacaoPerguntaRespostas { get; set; }
        public virtual DbSet<AvaliacaoRedacaoRespostaAluno> AvaliacaoRespostaAlunos { get; set; }
        public virtual DbSet<DocumentoDocumento> Documentos { get; set; }
        public virtual DbSet<OrganizacaoOrganizacao> Organizacoes { get; set; }
        public virtual DbSet<RedacaoRedacao> Redacoes { get; set; }
        public virtual DbSet<TemaRedacao> TemasRedacao { get; set; }
        public virtual DbSet<VestibularVestibular> Vestibulares { get; set; }
        public virtual DbSet<UsuarioOrganizacao> UsuariosOrganizacoes { get; set; }
        public virtual DbSet<VestibularTema> VestibularesTemas { get; set; }
        public virtual DbSet<NotificacaoNotificacao> Notificacoes { get; set; }
    }
}
