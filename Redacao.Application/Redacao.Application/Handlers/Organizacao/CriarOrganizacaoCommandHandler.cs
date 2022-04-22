using MediatR;
using Microsoft.Extensions.Logging;
using Redacao.Application.Commands.Organizacao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Organizacao
{
    public class CriarOrganizacaoCommandHandler : IRequestHandler<CriarOrganizacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<OrganizacaoOrganizacao> _repositorioOrganizacao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;
        public CriarOrganizacaoCommandHandler(IRepositorioGenerico<OrganizacaoOrganizacao> repositorioOrganizacao,
                                              UsuarioLogadoMiddlewareModel usuarioLogado)       
        {
            _repositorioOrganizacao = repositorioOrganizacao;
            _usuarioLogado = usuarioLogado;
        }
        public async Task<ResponseViewModel<string>> Handle(CriarOrganizacaoCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var organizacao = new OrganizacaoOrganizacao(request.Nome, request.Descricao, request.CorPrimaria, 
                                                             request.CorSecundaria, Guid.NewGuid(), request.TipoOrganizacao, 
                                                             0, _usuarioLogado.Id, DateTime.Now, null, true);

                var organizacaoValida = await organizacao.ValidaObjeto(organizacao);

                if (!organizacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(organizacaoValida);

                await _repositorioOrganizacao.Create(organizacao);
                await _repositorioOrganizacao.Save();

                _repositorioOrganizacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "oooooba... A organização foi criada com sucesso :)");
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
