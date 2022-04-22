using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Notificacao
{
    public class BuscarNotificacaoPorIdQuery : IRequest<ResponseViewModel<NotificacaoNotificacao>>
    {
        public BuscarNotificacaoPorIdQuery()
        {

        }

        public BuscarNotificacaoPorIdQuery(Int32 id)
        {
            this.Id = id;
        }

        public Int32 Id { get; set; }
    }
}
