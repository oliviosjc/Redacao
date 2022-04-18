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
    public class ResetarSenhaCommandHandler : IRequestHandler<ResetarSenhaCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;

        public ResetarSenhaCommandHandler(UserManager<UsuarioUsuario> userManager)
        {
            _userManager = userManager;
        }   

        public async Task<ResponseViewModel<string>> Handle(ResetarSenhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);

                if (usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrado nenhum usuário com este e-mail na base de dados :/ Tente novamente.");

                var resetarSenha = await _userManager.ResetPasswordAsync(usuario, request.Token, request.Senha);

                if(!resetarSenha.Succeeded)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Ocorreu um erro ao tentar resetar a senha :/ Tente novamente mais tarde.");

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A sua senha foi resetada com sucesso. Nos vemos dentro da plataforma :)");
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
