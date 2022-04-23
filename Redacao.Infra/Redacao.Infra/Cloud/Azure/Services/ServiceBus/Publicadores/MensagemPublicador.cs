using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Enums;
using Redacao.Infra.Configuracao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Publicador
{
    public class MensagemPublicador : IMensagemPublicador
    {
        private readonly ConfiguracaoFila _configuracaoFila;
        public MensagemPublicador(ConfiguracaoFila configuracaoFila)
        {
            _configuracaoFila = configuracaoFila;
        }

        public async Task Publicar(string mensagem, QueueClient queueClient)
        {
            try
            {
                await using (ServiceBusClient client = new ServiceBusClient(_configuracaoFila.Conexao))
                {
                    ServiceBusSender sender = client.CreateSender(queueClient.QueueName);

                    ServiceBusMessage message = new ServiceBusMessage(mensagem);

                    await sender.SendMessageAsync(message);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
