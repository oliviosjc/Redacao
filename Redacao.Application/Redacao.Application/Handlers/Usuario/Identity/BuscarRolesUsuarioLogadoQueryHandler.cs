using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Usuario.Identity;
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
    public class BuscarRolesUsuarioLogadoQueryHandler : IRequestHandler<BuscarRolesUsuarioLogadoQuery, ResponseViewModel<List<string>>>
    {
        private readonly UserManager<UsuarioUsuario> _usuarioManager;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public BuscarRolesUsuarioLogadoQueryHandler(UserManager<UsuarioUsuario> usuarioManager,
                                                    UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _usuarioManager = usuarioManager;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<List<string>>> Handle(BuscarRolesUsuarioLogadoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _usuarioManager.FindByIdAsync(_usuarioLogado.Id.ToString());

                if (usuario is null)
                    return ResponseReturnHelper<List<string>>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrado nenhum usuário logado.");

                var usuarioRoles = await _usuarioManager.GetRolesAsync(usuario);

                if(!usuarioRoles.Any())
                    return ResponseReturnHelper<List<string>>.GerarRetorno(HttpStatusCode.NoContent, "O usuário logado não possui nenhuma role vinculada.");
                else
                    return ResponseReturnHelper<List<string>>.GerarRetorno(HttpStatusCode.OK, usuarioRoles.ToList(), "As roles do usuário foram encontradas com sucesso :)");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<string>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<string>>.GerarRetorno(ex);
            }
        }
    }
}
