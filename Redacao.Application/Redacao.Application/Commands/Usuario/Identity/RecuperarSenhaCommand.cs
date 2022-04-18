using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class RecuperarSenhaCommand : IRequest<ResponseViewModel<string>>
    {
        public RecuperarSenhaCommand()
        {

        }

        public string Email { get; set; }
    }
}
