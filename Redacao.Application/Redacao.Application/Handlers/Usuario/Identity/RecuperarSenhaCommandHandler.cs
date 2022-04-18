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
    public class RecuperarSenhaCommandHandler : IRequestHandler<RecuperarSenhaCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _userManage;

        public RecuperarSenhaCommandHandler(UserManager<UsuarioUsuario> userManage)
        {
            _userManage = userManage;
        }

        public async Task<ResponseViewModel<string>> Handle(RecuperarSenhaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManage.FindByEmailAsync(request.Email);

                if (usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrado nenhum usuário com este e-mail na base de dados :/ Tente novamente.");

                var token = await _userManage.GeneratePasswordResetTokenAsync(usuario);

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, token ,"Você vai receber em breve um e-mail contendo as informações necessárias para resetar sua senha. Não esqueça de verificar seu SPAM!");
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
