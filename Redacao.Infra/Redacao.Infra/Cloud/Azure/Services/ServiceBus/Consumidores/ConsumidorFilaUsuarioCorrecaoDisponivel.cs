using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Repositorios;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Cliente.Model;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Consumidor
{
    public class ConsumidorFilaUsuarioCorrecaoDisponivel : BackgroundService
    {
        private static ClienteFilaUsuarioCorrecaoDisponivel _filaCliente;
        public ConsumidorFilaUsuarioCorrecaoDisponivel(ClienteFilaUsuarioCorrecaoDisponivel filaCliente)
        {
            _filaCliente = filaCliente;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ReceiveMessagesAsync();
        }

        private static async Task ReceiveMessagesAsync()
        {
            await Task.Factory.StartNew(() =>
            {
                var options = new MessageHandlerOptions(ExceptionMethod)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };

                _filaCliente.RegisterMessageHandler(ExecuteMessageProcessing, options);
            });
        }

        private static async Task ExecuteMessageProcessing(Message message, CancellationToken arg2)
        {
            try
            {
                var model = JsonConvert.DeserializeObject<AtualizarUsuarioCorrecaoDisponivelModel>(Encoding.UTF8.GetString(message.Body));

                await _filaCliente.CompleteAsync(message.SystemProperties.LockToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static async Task ExceptionMethod(ExceptionReceivedEventArgs arg)
        {
            await Task.Run(() =>
                Console.WriteLine($"Error occured. Error is {arg.Exception.Message}"));
        }
    }
}
