using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.ServiceBus;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Cliente.Model
{
    public class ClienteFilaUsuarioCorrecaoDisponivel : QueueClient
    {
        public ClienteFilaUsuarioCorrecaoDisponivel(string connectionString, string entityPath, ReceiveMode receiveMode = ReceiveMode.PeekLock, RetryPolicy retryPolicy = null) : base(connectionString, entityPath, receiveMode, retryPolicy)
        {
        }
    }
}
