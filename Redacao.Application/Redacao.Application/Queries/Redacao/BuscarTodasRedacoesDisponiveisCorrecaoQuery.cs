using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarTodasRedacoesDisponiveisCorrecaoQuery : IRequest<ResponseViewModel<List<RedacaoRedacao>>>
    {
        public BuscarTodasRedacoesDisponiveisCorrecaoQuery()
        {

        }

        public BuscarTodasRedacoesDisponiveisCorrecaoQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
