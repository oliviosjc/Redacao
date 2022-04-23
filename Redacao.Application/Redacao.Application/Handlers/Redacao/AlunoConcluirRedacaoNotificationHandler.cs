using MediatR;
using Newtonsoft.Json;
using Redacao.Application.Notifications.Redacao;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Cliente.Model;
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
        private readonly ClienteFilaUsuarioCorrecaoDisponivel _queueClient;

        public AlunoConcluirRedacaoNotificationHandler(IMensagemPublicador mensagemPublicador,
                                                       ClienteFilaUsuarioCorrecaoDisponivel queueClient)
        {
            _mensagemPublicador = mensagemPublicador;
            _queueClient = queueClient;
        }

        public async Task Handle(AlunoConcluirRedacaoNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                string mensagem = JsonConvert.SerializeObject(notification.Model);

                await _mensagemPublicador.Publicar(mensagem, _queueClient);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
