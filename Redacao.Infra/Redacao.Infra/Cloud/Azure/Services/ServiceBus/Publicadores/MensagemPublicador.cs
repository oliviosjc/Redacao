using Azure.Messaging.ServiceBus;
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

        public async Task PublicarMensagem(string message, RedacaoFilaEnum filaEnum)
        {
            try
            {
                if(filaEnum is RedacaoFilaEnum.ATUALIZAR_USUARIO_CORRECAO_DISPONIVEL)
                    await Executar(message, _configuracaoFila.Conexao, _configuracaoFila.NomeFilaUsuarioCorrecaoDisponivel);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task Executar(string m, string conexao, string nomeFila)
        {
            try
            {
                await using (ServiceBusClient client = new ServiceBusClient(conexao))
                {
                    ServiceBusSender sender = client.CreateSender(nomeFila);

                    ServiceBusMessage message = new ServiceBusMessage(m);

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
