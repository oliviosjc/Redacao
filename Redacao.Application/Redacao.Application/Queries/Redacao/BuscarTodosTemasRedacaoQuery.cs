using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarTodosTemasRedacaoQuery : IRequest<ResponseViewModel<List<TemaRedacao>>>
    {
        public BuscarTodosTemasRedacaoQuery()
        {

        }

        public BuscarTodosTemasRedacaoQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
