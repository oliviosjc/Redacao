using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Enums.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Categoria
{
    public class EditarCategoriaCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarCategoriaCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Nome { get; set; }

        public TipoCategoriaEnum TipoCategoria { get; set; }
    }
}
