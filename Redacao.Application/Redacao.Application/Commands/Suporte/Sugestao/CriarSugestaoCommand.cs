using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Enums.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Suporte.Sugestao
{
    public class CriarSugestaoCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarSugestaoCommand()
        {

        }

        public string Descricao { get; set; }

        public TipoSugestaoEnum Tipo { get; set; }
    }
}
