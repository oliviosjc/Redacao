using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class DesabilitarUsuarioCommandHandler : IRequestHandler<DesabilitarUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;

        public DesabilitarUsuarioCommandHandler(UserManager<UsuarioUsuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseViewModel<string>> Handle(DesabilitarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByIdAsync(request.Id.ToString());

                if (usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrado nenhum usuário com este Id na base de dados. Tente novamente.");

                await _userManager.SetLockoutEndDateAsync(usuario, DateTime.UtcNow.AddYears(10));

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "O usuário foi desabilitado com sucesso.");
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
