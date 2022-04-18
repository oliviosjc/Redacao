using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Enums.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Redacao
{
    public class RedacaoRedacao : EntidadeBase
    {
        public RedacaoRedacao()
        {

        }

        public string Descricao { get; private set; }

        public Int32 TemaRedacaoId { get; private set; }

        public Int32 UsuarioAlunoId { get; private set; }

        public Int32 UsuarioProfessorId { get; private set; }

        public Int32 OrganizacaoId { get; private set; }

        public Int32? AvaliacaoProfessorId { get; private set; }

        public virtual TipoRedacaoEnum TipoRedacao { get; private set; }

        public virtual StatusRedacaoEnum StatusRedacao { get; private set; }

        public virtual TemaRedacao TemaRedacao { get; private set; }

        public virtual UsuarioUsuario Usuario { get; private set; }

        public virtual ICollection<DocumentoDocumento> DocumentosRedacao { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }
    }
}
