using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class RealizarLoginUsuarioCommandHandler : IRequestHandler<RealizarLoginUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly SignInManager<UsuarioUsuario> _signInManager;
        private readonly UserManager<UsuarioUsuario> _userManager;
        private readonly IMediator _mediator;

        public RealizarLoginUsuarioCommandHandler(UserManager<UsuarioUsuario> userManager,
                                                  SignInManager<UsuarioUsuario> signInManager,
                                                  IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
            _signInManager = signInManager;
        }

        public async Task<ResponseViewModel<string>> Handle(RealizarLoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);

                if (usuario is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Nenhum usuário com este e-mail foi encontrado na base de dados. Verifique se sua conta foi ativada através do e-mail!");

                var resultado = await _signInManager.PasswordSignInAsync(request.Email, request.Senha, false, true);

                if(resultado.IsNotAllowed)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O seu usuário ainda está desativado! Acesse o e-mail de confirmação do cadastro para ativa-lo.");

                if(resultado.IsLockedOut)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O seu usuário foi impedido de entrar na plataforma. Contate o suporte para mais informações.");

                if(!resultado.Succeeded)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Usuário ou senha incorretos. Tente novamente :)");

                var token = await _mediator.Send(new GerarTokenUsuarioCommand{ Email = usuario.Email });

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, token, "Login realizado com sucesso. Seja bem vindo :)");
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

