using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarMinhasRedacoesQuery : IRequest<ResponseViewModel<List<RedacaoRedacao>>>
    {
        public BuscarMinhasRedacoesQuery()
        {

        }
    }
}
