using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Categoria;
using Redacao.Domain.Enums.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Categoria
{
    public class BuscarTodasCategoriasPorTipoQuery : IRequest<ResponseViewModel<List<CategoriaCategoria>>>
    {
        public BuscarTodasCategoriasPorTipoQuery()
        {

        }

        public BuscarTodasCategoriasPorTipoQuery(TipoCategoriaEnum tipoCategoria, RequestPaginacao paginacao)
        {

        }

        public TipoCategoriaEnum TipoCategoria { get; set; }

        public RequestPaginacao Paginacao { get; set; }
    }
}
