using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Redacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class BuscarMinhasRedacoesQueryHandler : IRequestHandler<BuscarMinhasRedacoesQuery, ResponseViewModel<List<RedacaoRedacao>>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public BuscarMinhasRedacoesQueryHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao,
                                                UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _usuarioLogado = usuarioLogado;
            _repositorioRedacao = repositorioRedacao;
        }

        public async Task<ResponseViewModel<List<RedacaoRedacao>>> Handle(BuscarMinhasRedacoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var redacoes = await _repositorioRedacao.GetAll(wh => wh.Ativo
                                                                && wh.UsuarioAlunoId == _usuarioLogado.Id, null);

                if(!redacoes.Any())
                    return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma redação para o usuário logado.");

                return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(HttpStatusCode.OK, "Redações do usuário encontradas com sucesso :)");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(ex);
            }
        }
    }
}
