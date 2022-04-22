using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class SetarRolesUsuarioCommandHandler : IRequestHandler<SetarRolesUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _usuarioManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public SetarRolesUsuarioCommandHandler(UserManager<UsuarioUsuario> usuarioManager,
                                               RoleManager<Role> roleManager,
                                               UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _usuarioManager = usuarioManager;
            _roleManager = roleManager;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(SetarRolesUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioManager.FindByIdAsync(_usuarioLogado.Id.ToString());

                if(usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O usuário logado não foi encontrado na base de dados :/ Tente novamente.");

                foreach(var role in request.Roles)
                {
                    var roleExiste = await _roleManager.FindByNameAsync(role);

                    if(roleExiste is null)
                        return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A role não foi encontrada na base de dados.");
                }

                var usuarioRoles = await _usuarioManager.GetRolesAsync(usuario);

                if(usuarioRoles.Any())
                    await _usuarioManager.RemoveFromRolesAsync(usuario, usuarioRoles);

                await _usuarioManager.AddToRolesAsync(usuario, request.Roles);

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "As roles foram setadas ao usuário com sucesso!");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<string>.GerarRetorno(ex);
            }
        }
    }
}
