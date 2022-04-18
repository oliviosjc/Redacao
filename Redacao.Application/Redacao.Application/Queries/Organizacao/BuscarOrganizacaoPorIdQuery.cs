using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Organizacao
{
    public class BuscarOrganizacaoPorIdQuery : IRequest<ResponseViewModel<OrganizacaoOrganizacao>>
    {
        public BuscarOrganizacaoPorIdQuery()
        {

        }

        public Int32 Id { get; set; }
    }
}
