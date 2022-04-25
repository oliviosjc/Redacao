using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Suporte.Sugestao;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Suporte.Sugestao
{
    public class BuscarMinhasSugestoesQueryHandler : IRequestHandler<BuscarMinhasSugestoesQuery, ResponseViewModel<List<SugestaoSugestao>>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public BuscarMinhasSugestoesQueryHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao,
                                                 UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioSugestao = repositorioSugestao;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<List<SugestaoSugestao>>> Handle(BuscarMinhasSugestoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestoes = await _repositorioSugestao.GetAll(wh => wh.Ativo
                                                            && wh.UsuarioCriadorId == _usuarioLogado.Id,
                                                            null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, 
                                                            request.Paginacao.OrdernarDecrescente);

                if(sugestoes.Any())
                    return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma sugestão sua na base de dados.");

                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(HttpStatusCode.OK, sugestoes.ToList() ,"Suas sugestões foram encontradas com sucesso.");

            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(ex);
            }
        }
    }
}
