using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Notificacao;
using Redacao.Domain.Entidades.Notificacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Notificacao
{
    public class BuscarNotificacaoPorIdQueryHandler : IRequestHandler<BuscarNotificacaoPorIdQuery, ResponseViewModel<NotificacaoNotificacao>>
    {
        private readonly IRepositorioGenerico<NotificacaoNotificacao> _repositorioNotificacao;

        public BuscarNotificacaoPorIdQueryHandler(IRepositorioGenerico<NotificacaoNotificacao> repositorioNotificacao)
        {
            _repositorioNotificacao = repositorioNotificacao;
        }

        public async Task<ResponseViewModel<NotificacaoNotificacao>> Handle(BuscarNotificacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notificacao = await _repositorioNotificacao.Get(wh => wh.Ativo
                                                                    && wh.Id == request.Id);

                if (notificacao is null)
                    return ResponseReturnHelper<NotificacaoNotificacao>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma notificação com este ID :( Tente novamente.");

                return ResponseReturnHelper<NotificacaoNotificacao>.GerarRetorno(HttpStatusCode.OK, notificacao, "A notificação foi encontrada com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<NotificacaoNotificacao>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<NotificacaoNotificacao>.GerarRetorno(ex);
            }
        }
    }
}
