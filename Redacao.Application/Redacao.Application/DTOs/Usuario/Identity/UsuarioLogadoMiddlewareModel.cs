using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.DTOs.Usuario.Identity
{
    public class UsuarioLogadoMiddlewareModel
    {
        public UsuarioLogadoMiddlewareModel()
        {

        }

        public UsuarioLogadoMiddlewareModel(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; set; }

        public Int32 OrganizacaoId { get; set; }
    }
}
