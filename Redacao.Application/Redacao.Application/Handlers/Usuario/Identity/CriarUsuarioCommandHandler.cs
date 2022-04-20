using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario.Identity;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Notifications.Usuario.Identity;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Enums.Usuario;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario.Identity
{
    public class CriarUsuarioCommandHandler : IRequestHandler<CriarUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<OrganizacaoOrganizacao> _repositorioOrganizacao;
        private readonly UserManager<UsuarioUsuario> _userManager;
        private readonly IMediator _mediator;

        public CriarUsuarioCommandHandler(IRepositorioGenerico<OrganizacaoOrganizacao> repositorioOrganizacao,
                                          UserManager<UsuarioUsuario> userManager,
                                          IMediator mediator)
        {
            _repositorioOrganizacao = repositorioOrganizacao;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = new UsuarioUsuario(request.Nome, request.CPF, request.RG, request.CNPJ, TipoUsuarioEnum.ALUNO, request.NumeroCelular, request.Email, 0, 0);

                var usuarioValido = await usuario.ValidaObjeto(usuario);

                if (!usuarioValido.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(usuarioValido);

                var resultado = await _userManager.CreateAsync(usuario, request.Senha);

                if (!resultado.Succeeded)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Lamentamos, aconteceu um erro interno ao tentar cadastrar o usuário. Tente novamente mais tarde :/");
                else
                {
                    await _mediator.Publish(new CriarUsuarioNotification { Email = usuario.Email });
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooooba... Seu cadastro foi efetuado com sucesso! Verifique seu e-mail para confirmar o cadastro :)");
                }
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
