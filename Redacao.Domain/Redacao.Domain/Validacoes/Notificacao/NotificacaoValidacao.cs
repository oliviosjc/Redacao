using FluentValidation;
using Redacao.Domain.Entidades.Notificacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Notificacao
{
    public class NotificacaoValidacao : AbstractValidator<NotificacaoNotificacao>
    {
        public NotificacaoValidacao()
        {
            RuleFor(r => r.Mensagem).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(r => r.TipoNotificacao).NotEmpty().NotNull().IsInEnum();
            RuleFor(r => r.UsuarioId).NotNull().NotEmpty();
        }
    }
}
