using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Enums.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Notificacao
{
    public class EditarNotificacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarNotificacaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Mensagem { get; set; }

        public TipoNotificacaoEnum TipoNotificacao { get; set; }
    }
}
