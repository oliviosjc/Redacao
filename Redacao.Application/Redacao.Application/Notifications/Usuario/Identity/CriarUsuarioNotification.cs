using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Notifications.Usuario.Identity
{
    public class CriarUsuarioNotification : INotification
    {
        public CriarUsuarioNotification()
        {

        }

        public string Email { get; set; }
    }
}
