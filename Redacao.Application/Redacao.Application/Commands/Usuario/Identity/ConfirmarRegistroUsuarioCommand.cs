using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class ConfirmarRegistroUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public ConfirmarRegistroUsuarioCommand()
        {

        }

        public ConfirmarRegistroUsuarioCommand(Int32 usuarioId, string token)
        {
            this.UsuarioId = usuarioId;
            this.Token = token;
        }

        public Int32 UsuarioId { get; set; }

        public string Token { get; set; }
    }
}
