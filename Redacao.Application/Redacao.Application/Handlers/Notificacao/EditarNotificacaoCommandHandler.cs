using MediatR;
using Redacao.Application.Commands.Notificacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
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
    public class EditarNotificacaoCommandHandler : IRequestHandler<EditarNotificacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<NotificacaoNotificacao> _repositorioNotificacao;

        public EditarNotificacaoCommandHandler(IRepositorioGenerico<NotificacaoNotificacao> repositorioNotificacao)
        {
            _repositorioNotificacao = repositorioNotificacao;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarNotificacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var notificacao = await _repositorioNotificacao.Get(wh => wh.Id == request.Id 
                                                                    && wh.Ativo);

                if (notificacao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrada nenhuma notificação com este Id.");

                notificacao = new NotificacaoNotificacao(notificacao.Visualizada, request.Mensagem,
                                                         request.TipoNotificacao, notificacao.UsuarioId,
                                                         notificacao.Id, notificacao.UsuarioCriadorId,
                                                         notificacao.CriadoEm, DateTime.UtcNow, true);

                var notificacaoValida = await notificacao.ValidaObjeto(notificacao);

                if(!notificacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(notificacaoValida);

                await _repositorioNotificacao.Update(notificacao);
                await _repositorioNotificacao.Save();

                _repositorioNotificacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A notificação foi atualizaca com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
        }
    }
}
