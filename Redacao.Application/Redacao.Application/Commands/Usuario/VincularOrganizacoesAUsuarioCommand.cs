using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario
{
    public class VincularOrganizacoesAUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public VincularOrganizacoesAUsuarioCommand()
        {

        }

        public Int32 UsuarioId { get; set; }

        public List<Int32> OrganizacoesIds { get; set; }
    }
}
