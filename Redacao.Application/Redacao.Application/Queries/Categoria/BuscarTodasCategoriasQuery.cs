using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Categoria
{
    public class BuscarTodasCategoriasQuery : IRequest<ResponseViewModel<List<CategoriaCategoria>>>
    {
        public BuscarTodasCategoriasQuery()
        {

        }

        public BuscarTodasCategoriasQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
