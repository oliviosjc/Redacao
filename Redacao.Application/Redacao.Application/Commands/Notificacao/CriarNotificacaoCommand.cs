using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Enums.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Notificacao
{
    public class CriarNotificacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public CriarNotificacaoCommand()
        {

        }

        public string Mensagem { get; set; }

        public TipoNotificacaoEnum TipoNotificacao { get; set; }

        public Int32 UsuarioId { get; set; }

        public UsuarioLogadoMiddlewareModel UsuarioLogado { get; set; }
    }
}
