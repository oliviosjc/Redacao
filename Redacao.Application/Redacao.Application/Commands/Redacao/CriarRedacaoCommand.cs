using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class CriarRedacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarRedacaoCommand()
        {

        }

        public string Descricao { get; set; }

        public Int32 TemaRedacaoId { get; set; }

        public Int32 VestibularId { get; set; }
    }
}
