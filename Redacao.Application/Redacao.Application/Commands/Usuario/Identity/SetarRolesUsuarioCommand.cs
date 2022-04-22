using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class SetarRolesUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public SetarRolesUsuarioCommand()
        {

        }

        public SetarRolesUsuarioCommand(List<string> roles)
        {
            this.Roles = roles;
        }

        public List<string> Roles { get; set; }
    }
}
