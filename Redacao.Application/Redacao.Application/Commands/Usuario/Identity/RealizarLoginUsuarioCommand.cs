using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class RealizarLoginUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public RealizarLoginUsuarioCommand()
        {

        }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
