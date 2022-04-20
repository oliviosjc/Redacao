using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Queries.Usuario.Identity;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class BuscarRolesUsuarioLogadoQueryHandler : IRequestHandler<BuscarRolesUsuarioLogadoQuery, ResponseViewModel<List<UsuarioRole>>>
    {
        private readonly UserManager<UsuarioUsuario> _usuarioManager;

        public BuscarRolesUsuarioLogadoQueryHandler(UserManager<UsuarioUsuario> usuarioManager)
        {
            _usuarioManager = usuarioManager;
        }

        public Task<ResponseViewModel<List<UsuarioRole>>> Handle(BuscarRolesUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
