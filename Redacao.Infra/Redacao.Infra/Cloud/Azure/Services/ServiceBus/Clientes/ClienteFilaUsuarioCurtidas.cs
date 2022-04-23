using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Clientes
{
    public class ClienteFilaUsuarioCurtidas : QueueClient
    {
        public ClienteFilaUsuarioCurtidas(string connectionString, string entityPath, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null) : base(connectionString, entityPath, receiveMode, retryPolicy)
        {
        }
    }
}
