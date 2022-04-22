using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Suporte.Sugestao
{
    public class BuscarMinhasSugestoesQuery : IRequest<ResponseViewModel<List<SugestaoSugestao>>>
    {
        public BuscarMinhasSugestoesQuery()
        {

        }

        public BuscarMinhasSugestoesQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
