using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Queries.Notificacao
{
    public class BuscarTodasNotificacoesQuery : IRequest<ResponseViewModel<List<NotificacaoNotificacao>>>
    {
        public BuscarTodasNotificacoesQuery()
        {

        }

        public RequestPaginacao Paginacao { get; set; }
    }
}
