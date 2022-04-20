using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Vestibular
{
    public class EditarVestibularCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarVestibularCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
