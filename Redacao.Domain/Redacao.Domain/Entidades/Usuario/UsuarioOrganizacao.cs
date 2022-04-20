using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Validacoes.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Usuario
{
    public class UsuarioOrganizacao : EntidadeBase
    {
        public UsuarioOrganizacao()
        {

        }

        public UsuarioOrganizacao(Int32 usuarioId, Int32 organizacaoId, Int32 id, Int32 usuarioCriadorId,
                                  DateTime criadoEm, DateTime? modificadoEm, bool ativo)
        {
            this.SetarOrganizacaoId(organizacaoId);
            this.SetarUsuarioId(usuarioId);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public Int32 OrganizacaoId { get; private set; }

        public Int32 UsuarioId { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }

        public virtual UsuarioUsuario Usuario { get; private set; }

        private void SetarUsuarioId(Int32 usuarioId)
        {
            this.UsuarioId = usuarioId;
        }

        private void SetarOrganizacaoId(Int32 organizacaoId)
        {
            this.OrganizacaoId = organizacaoId;
        }

        public async Task<ValidationResult> ValidaObjeto(UsuarioOrganizacao objeto)
        {
            UsuarioOrganizacaoValidacao validacao = new UsuarioOrganizacaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
