using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Notifications.Redacao
{
    public class AlunoConcluirRedacaoNotification : INotification
    {
        public AlunoConcluirRedacaoNotification()
        {

        }

        public AlunoConcluirRedacaoNotification(AlunoConcluirRedacaoCommand command)
        {
            this.Model = new AtualizarUsuarioCorrecaoDisponivelModel(1, false);
        }

        public AtualizarUsuarioCorrecaoDisponivelModel Model { get; set; }
    }
}
