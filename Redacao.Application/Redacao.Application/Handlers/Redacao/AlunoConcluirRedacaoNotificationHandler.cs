using MediatR;
using Newtonsoft.Json;
using Redacao.Application.Notifications.Redacao;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Enums;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Publicador;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class AlunoConcluirRedacaoNotificationHandler : INotificationHandler<AlunoConcluirRedacaoNotification>
    {
        private readonly IMensagemPublicador _mensagemPublicador;

        public AlunoConcluirRedacaoNotificationHandler(IMensagemPublicador mensagemPublicador)
        {
            _mensagemPublicador = mensagemPublicador;
        }

        public async Task Handle(AlunoConcluirRedacaoNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                string mensagem = JsonConvert.SerializeObject(notification.Model);
                await _mensagemPublicador.PublicarMensagem(mensagem, RedacaoFilaEnum.ATUALIZAR_USUARIO_CORRECAO_DISPONIVEL);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
