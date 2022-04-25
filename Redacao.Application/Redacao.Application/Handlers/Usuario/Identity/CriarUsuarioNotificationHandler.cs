using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Infra.Email.Models;
using Redacao.Infra.Email.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Notifications.Usuario.Identity
{
    public class CriarUsuarioNotificationHandler : INotificationHandler<CriarUsuarioNotification>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;
        private readonly IEmailService _emailService;

        public CriarUsuarioNotificationHandler(UserManager<UsuarioUsuario> userManager,
                                               IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }
            
        public async Task Handle(CriarUsuarioNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(notification.Email);

                string confirmacaoToken = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);

                var requestEmail = new RequestEmail
                {
                    Anexos = null,
                    Assunto = "Confirme a criação da sua conta em RedacaoAPP",
                    Corpo = confirmacaoToken,
                    Para = notification.Email
                };

                await _emailService.EnviarEmail(requestEmail);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
