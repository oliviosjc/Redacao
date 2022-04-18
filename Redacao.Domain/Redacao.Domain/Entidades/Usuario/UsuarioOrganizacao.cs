using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Entidades.Usuario
{
    public class UsuarioOrganizacao
    {
        public UsuarioOrganizacao()
        {

        }

        public Int32 OrganizacaoId { get; private set; }

        public Int32 UsuarioId { get; private set; }

        public virtual OrganizacaoOrganizacao Organizacao { get; private set; }

        public virtual UsuarioUsuario Usuario { get; private set; }
    }
}
