using Microsoft.Azure.ServiceBus;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Publicador
{
    public interface IMensagemPublicador
    {
        Task Publicar(string mensagem, QueueClient queueClient);
    }
}   
