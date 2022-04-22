using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class EditarTemaRedacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarTemaRedacaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public Int32 CategoriaId { get; set; }
    }
}
