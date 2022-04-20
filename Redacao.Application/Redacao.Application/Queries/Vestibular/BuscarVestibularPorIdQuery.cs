using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Vestibular
{
    public class BuscarVestibularPorIdQuery : IRequest<ResponseViewModel<VestibularVestibular>>
    {
        public BuscarVestibularPorIdQuery()
        {

        }

        public Int32 Id { get; set; }
    }
}
