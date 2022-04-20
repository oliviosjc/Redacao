using FluentValidation.Results;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Enums.Notificacao;
using Redacao.Domain.Validacoes.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Entidades.Notificacao
{
    public class NotificacaoNotificacao : EntidadeBase
    {
        public NotificacaoNotificacao()
        {
                
        }

        public NotificacaoNotificacao(bool visualizada, string mensagem, TipoNotificacaoEnum tipoNotificacao, 
                                      Int32 usuarioId, Int32 id, Int32 usuarioCriadorId, DateTime criadoEm,
                                      DateTime? modificadoEm, bool ativo)
        {
            this.SetarVisualizada(visualizada);
            this.SetarMensagem(mensagem);
            this.SetarTipoNoficacao(tipoNotificacao);
            this.SetarUsuarioId(usuarioId);
            this.SetarId(id);
            this.SetarUsuarioCriadorId(usuarioCriadorId);
            this.SetarCriadoEm(criadoEm);
            this.SetarModificadoEm(modificadoEm);
            this.SetarAtivo(ativo);
        }

        public bool Visualizada { get; private set; }

        public string Mensagem { get; private set; }

        public TipoNotificacaoEnum TipoNotificacao { get; private set; }

        public Int32 UsuarioId { get; private set; }

        public virtual UsuarioUsuario Usuario { get; private set; }

        private void SetarVisualizada(bool visualizada)
        {
            this.Visualizada = visualizada;
        }

        private void SetarMensagem(string mensagem)
        {
            this.Mensagem = mensagem;
        }

        private void SetarTipoNoficacao(TipoNotificacaoEnum tipoNotificacao)
        {
            this.TipoNotificacao = tipoNotificacao;
        }
        
        private void SetarUsuarioId(Int32 usuarioId)
        {
            this.UsuarioId = usuarioId;
        }

        public async Task<ValidationResult> ValidaObjeto(NotificacaoNotificacao objeto)
        {
            NotificacaoValidacao validacao = new NotificacaoValidacao();
            return await validacao.ValidateAsync(objeto);
        }
    }
}
