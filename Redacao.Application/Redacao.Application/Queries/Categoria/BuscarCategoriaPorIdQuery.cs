using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Categoria
{
    public class BuscarCategoriaPorIdQuery : IRequest<ResponseViewModel<CategoriaCategoria>>
    {
        public BuscarCategoriaPorIdQuery()
        {

        }

        public BuscarCategoriaPorIdQuery(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; set; }
    }
}
