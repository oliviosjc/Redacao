using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class GerarTokenUsuarioCommand : IRequest<string>
    {
        public GerarTokenUsuarioCommand()
        {

        }

        public GerarTokenUsuarioCommand(string email)
        {
            this.Email = email;
        }

        public string Email { get; set; }
    }
}
