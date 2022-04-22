using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Suporte.Sugestao
{
    public class BuscarSugestaoPorIdQuery : IRequest<ResponseViewModel<SugestaoSugestao>>
    {
        public BuscarSugestaoPorIdQuery()
        {

        }

        public BuscarSugestaoPorIdQuery(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; set; }
    }
}
