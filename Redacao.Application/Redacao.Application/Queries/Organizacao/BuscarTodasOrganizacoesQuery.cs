using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Organizacao
{
    public class BuscarTodasOrganizacoesQuery : IRequest<ResponseViewModel<List<OrganizacaoOrganizacao>>>
    {
        public BuscarTodasOrganizacoesQuery()
        {

        }

        public BuscarTodasOrganizacoesQuery(RequestPaginacao paginacao)
        {
            this.Paginacao = paginacao;
        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
