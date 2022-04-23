using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios;
using Redacao.Domain.Repositorios.Dapper.TemaRedacao;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Clientes;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Consumidores
{
    public class ConsumidorFilaUsuarioCurtidas : BackgroundService
    {
        private static ClienteFilaUsuarioCurtidas _filaCliente;
        private static ITemaRedacaoRepositorio _repositorio;
        public ConsumidorFilaUsuarioCurtidas(ClienteFilaUsuarioCurtidas filaCliente,
                                             ITemaRedacaoRepositorio repositorio)
        {
            _filaCliente = filaCliente;
            _repositorio = repositorio;
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
                var model = JsonConvert.DeserializeObject<UsuarioCurtidasModel>(Encoding.UTF8.GetString(message.Body));

                await _repositorio.Curtir(model.UsuarioId, model.TemaRedacaoId, model.Curtida);

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
