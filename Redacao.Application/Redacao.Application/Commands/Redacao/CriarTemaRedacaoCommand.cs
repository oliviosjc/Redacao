using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands
{
    public class CriarTemaRedacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarTemaRedacaoCommand()
        {

        }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Int32 VestibularId { get; set; }

        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
