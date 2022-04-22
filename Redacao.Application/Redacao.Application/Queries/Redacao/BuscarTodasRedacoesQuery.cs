using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarTodasRedacoesQuery : IRequest<ResponseViewModel<List<RedacaoRedacao>>>
    {
        public BuscarTodasRedacoesQuery()
        {
                
        }

        public BuscarTodasRedacoesQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
