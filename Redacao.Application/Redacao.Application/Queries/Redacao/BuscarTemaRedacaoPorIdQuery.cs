using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarTemaRedacaoPorIdQuery : IRequest<ResponseViewModel<TemaRedacao>>
    {
        public BuscarTemaRedacaoPorIdQuery()
        {

        }

        public BuscarTemaRedacaoPorIdQuery(Int32 id)
        {
            this.Id = id;
        }
        public Int32 Id { get; set; }
    }
}
