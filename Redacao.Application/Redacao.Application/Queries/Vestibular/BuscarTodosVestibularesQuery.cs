using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Vestibular
{
    public class BuscarTodosVestibularesQuery : IRequest<ResponseViewModel<List<VestibularVestibular>>>
    {
        public BuscarTodosVestibularesQuery()
        {

        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
