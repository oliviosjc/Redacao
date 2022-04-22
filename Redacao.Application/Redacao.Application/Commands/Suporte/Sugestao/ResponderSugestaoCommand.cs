using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Suporte.Sugestao
{
    public class ResponderSugestaoCommand : IRequest<ResponseViewModel<string>>
    {
        public ResponderSugestaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Resposta { get; set; }
    }
}
