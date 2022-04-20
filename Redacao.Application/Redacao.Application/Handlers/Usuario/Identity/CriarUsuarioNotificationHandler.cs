using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Notifications.Usuario.Identity
{
    public class CriarUsuarioNotificationHandler : INotificationHandler<CriarUsuarioNotification>
    {
        public async Task Handle(CriarUsuarioNotification notification, CancellationToken cancellationToken)
        {
        }
    }
}
