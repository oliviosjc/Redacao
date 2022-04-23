using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Redacao
{
    public class TemaRedacaoUsuarioCurtida
    {
        public TemaRedacaoUsuarioCurtida()
        {

        }

        public TemaRedacaoUsuarioCurtida(Int32 usuarioId, Int32 temaRedacaoId, bool curtida)
        {
            this.UsuarioId = usuarioId;
            this.TemaRedacaoId = temaRedacaoId;
            this.Curtida = curtida;
        }

        public Int32 UsuarioId { get; private set; }

        public Int32 TemaRedacaoId { get; private set; }

        public bool Curtida { get; private set; }

        private void SetarUsuarioId(Int32 usuarioId)
        {
            this.UsuarioId = usuarioId;
        }

        private void SetarTemaRedacaoId(Int32 temaRedacaoId)
        {
            this.TemaRedacaoId = temaRedacaoId;
        }

        private void SetarCurtida(bool curtida)
        {
            this.Curtida = curtida;
        }
    }
}
