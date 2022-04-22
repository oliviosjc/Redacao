using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Enums.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Categoria
{
    public class CriarCategoriaCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarCategoriaCommand()
        {

        }

        public string Nome { get; set; }

        public TipoCategoriaEnum TipoCategoria { get; set; }
    }
}
