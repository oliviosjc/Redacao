using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class ProfessorGarantirCorrecaoCommand : IRequest<ResponseViewModel<string>>
    {
        public ProfessorGarantirCorrecaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
