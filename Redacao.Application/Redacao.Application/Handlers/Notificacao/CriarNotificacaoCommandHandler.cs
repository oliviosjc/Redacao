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
    public class CriarNotificacaoCommandHandler : IRequestHandler<CriarNotificacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<NotificacaoNotificacao> _repositorioNotificacao;

        public CriarNotificacaoCommandHandler(IRepositorioGenerico<NotificacaoNotificacao> repositorioNotificacao)
        {
            _repositorioNotificacao = repositorioNotificacao;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarNotificacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var notificacao = new NotificacaoNotificacao(false, request.Mensagem, request.TipoNotificacao, request.UsuarioId, 0, request.UsuarioLogado.Id, DateTime.UtcNow, null, true);

                var notificacaoValida = await notificacao.ValidaObjeto(notificacao);

                if(!notificacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(notificacaoValida);

                await _repositorioNotificacao.Create(notificacao);
                await _repositorioNotificacao.Save();

                _repositorioNotificacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "oooooba. A notificação foi criada com sucesso :)");
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
