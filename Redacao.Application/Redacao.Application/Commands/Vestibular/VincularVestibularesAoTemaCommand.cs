using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Vestibular
{
    public class VincularVestibularesAoTemaCommand : IRequest<ResponseViewModel<string>>
    {
        public VincularVestibularesAoTemaCommand()
        {

        }

        public Int32 TemaId { get; set; }
        public List<Int32> VestibularesIds { get; set; }
        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
