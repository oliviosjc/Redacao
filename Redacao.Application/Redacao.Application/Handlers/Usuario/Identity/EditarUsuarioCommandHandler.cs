using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Enums.Usuario;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class EditarUsuarioCommandHandler : IRequestHandler<EditarUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly UserManager<UsuarioUsuario> _userManager;
        public EditarUsuarioCommandHandler(UserManager<UsuarioUsuario> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ResponseViewModel<string>> Handle(EditarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByIdAsync(request.Id.ToString());

                if(usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O usuário que deseja editar não existe na base de dados :/ Tente novamente.");

                usuario = new UsuarioUsuario(request.Nome, request.CPF, request.RG, request.CNPJ, usuario.TipoUsuario, usuario.PhoneNumber, usuario.Email, usuario.QuantidadeCorrecoesDisponiveis, usuario.Id);

                var usuarioValido = await usuario.ValidaObjeto(usuario);

                if (!usuarioValido.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(usuarioValido);

                var resultado = await _userManager.UpdateAsync(usuario);

                if (!resultado.Succeeded)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Lamentamos, aconteceu um erro interno ao tentar editar o usuário. Tente novamente mais tarde :/");
                else
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooooba... Seu usuároi foi editado com sucesso!");
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
