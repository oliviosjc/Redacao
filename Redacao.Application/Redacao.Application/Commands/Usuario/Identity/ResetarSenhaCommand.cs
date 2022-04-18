using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class ResetarSenhaCommand : IRequest<ResponseViewModel<string>>
    {
        public ResetarSenhaCommand()
        {

        }
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }
    }
}
