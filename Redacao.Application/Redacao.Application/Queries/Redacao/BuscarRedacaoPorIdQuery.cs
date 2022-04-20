﻿using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Redacao
{
    public class BuscarRedacaoPorIdQuery : IRequest<ResponseViewModel<RedacaoRedacao>>
    {
        public BuscarRedacaoPorIdQuery()
        {

        }

        public Int32 Id { get; set; }
    }
}
