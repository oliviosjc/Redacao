using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class AlunoConcluirRedacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public AlunoConcluirRedacaoCommand()
        {

        }

        public AlunoConcluirRedacaoCommand(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; set; }
    }
}
