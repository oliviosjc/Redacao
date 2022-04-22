using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Enums.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Suporte.Sugestao
{
    public class EditarSugestaoCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarSugestaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Descricao { get; set; }

        public TipoSugestaoEnum Tipo { get; set; }
    }
}
