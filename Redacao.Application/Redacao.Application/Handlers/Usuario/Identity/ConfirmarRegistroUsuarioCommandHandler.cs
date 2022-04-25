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
    public class ConfirmarRegistroUsuarioCommandHandler : IRequestHandler<ConfirmarRegistroUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;

        public ConfirmarRegistroUsuarioCommandHandler(UserManager<UsuarioUsuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ResponseViewModel<string>> Handle(ConfirmarRegistroUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByIdAsync(request.UsuarioId.ToString());

                if (usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Nenhum usuário com este id foi encontrado na base de dados.");

                var confirmarUsuario = await _userManager.ConfirmEmailAsync(usuario, request.Token);

                if(!confirmarUsuario.Succeeded)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Ocorreu um erro ao confirmar o registro deste usuário :/ Tente novamente.");

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooba, seu usuário foi ativado com sucesso. Boas redações :)");
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
