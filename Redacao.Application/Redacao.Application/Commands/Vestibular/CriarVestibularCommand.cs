using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Vestibular
{
    public class CriarVestibularCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarVestibularCommand()
        {

        }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataProva { get; set; }
    }
}
