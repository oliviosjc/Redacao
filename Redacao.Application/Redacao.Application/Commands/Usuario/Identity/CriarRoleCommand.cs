using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class CriarRoleCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarRoleCommand()
        {

        }

        public string Nome { get; set; }
    }
}
