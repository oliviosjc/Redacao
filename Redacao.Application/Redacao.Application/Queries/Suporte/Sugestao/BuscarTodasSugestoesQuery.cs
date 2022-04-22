using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Suporte.Sugestao
{
    public class BuscarTodasSugestoesQuery : IRequest<ResponseViewModel<List<SugestaoSugestao>>>
    {
        public BuscarTodasSugestoesQuery()
        {

        }

        public BuscarTodasSugestoesQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
