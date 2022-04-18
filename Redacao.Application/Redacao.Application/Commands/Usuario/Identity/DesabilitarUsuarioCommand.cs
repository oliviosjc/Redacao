using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class DesabilitarUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public DesabilitarUsuarioCommand()
        {

        }

        public Int32 Id { get; set; }
    }
}
