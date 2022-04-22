using MediatR;
using Microsoft.AspNetCore.Identity;
using Redacao.Application.Commands.Usuario;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Usuario
{
    public class VincularOrganizacoesAUsuarioCommandHandler : IRequestHandler<VincularOrganizacoesAUsuarioCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<UsuarioOrganizacao> _repositorioUsuarioOrganizacao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public VincularOrganizacoesAUsuarioCommandHandler(IRepositorioGenerico<UsuarioOrganizacao> repositorioUsuarioOrganizacao,
                                                          UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioUsuarioOrganizacao = repositorioUsuarioOrganizacao;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(VincularOrganizacoesAUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioOrganizacoes = await _repositorioUsuarioOrganizacao.GetAll(wh => wh.Ativo 
                                                                                   && wh.UsuarioId == request.UsuarioId, null);

                await _repositorioUsuarioOrganizacao.Delete(usuarioOrganizacoes.ToList());

                var uo = new List<UsuarioOrganizacao>();

                foreach (var organizacaoId in request.OrganizacoesIds.Distinct())
                {
                    var usuarioOrganizacao = new UsuarioOrganizacao(request.UsuarioId, organizacaoId, 0, _usuarioLogado.Id, DateTime.UtcNow, null, true);
                    var usuarioOrganizacaoValido = await usuarioOrganizacao.ValidaObjeto(usuarioOrganizacao);

                    if (usuarioOrganizacaoValido.IsValid)
                        uo.Add(usuarioOrganizacao);
                };

                await _repositorioUsuarioOrganizacao.Create(uo);
                await _repositorioUsuarioOrganizacao.Save();

                _repositorioUsuarioOrganizacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "As organizações foram setadas para o usuário.");
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
