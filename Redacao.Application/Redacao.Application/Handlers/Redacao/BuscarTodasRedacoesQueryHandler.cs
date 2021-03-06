using MediatR;
using Redacao.Application.DTOs;
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
    public class BuscarTodasRedacoesQueryHandler : IRequestHandler<BuscarTodasRedacoesQuery, ResponseViewModel<List<RedacaoRedacao>>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;

        public BuscarTodasRedacoesQueryHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao)
        {
            _repositorioRedacao = repositorioRedacao;
        }

        public async Task<ResponseViewModel<List<RedacaoRedacao>>> Handle(BuscarTodasRedacoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var redacoes = await _repositorioRedacao.GetAll(wh => wh.Ativo, null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if (!redacoes.Any())
                    return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhuma redação na base de dados. Tente novamente com outros filtros!");

                var totalRedacoes = await _repositorioRedacao.Count();

                ResponsePaginacao responsePaginacao = new ResponsePaginacao
                {
                    TotalPaginas = totalRedacoes / request.Paginacao.TamanhoPagina,
                    TotalRegistros = totalRedacoes,
                    TamanhoPagina = request.Paginacao.TamanhoPagina,
                    NumeroPagina = request.Paginacao.NumeroPagina
                };

                return ResponseReturnHelper<List<RedacaoRedacao>>.GerarRetorno(HttpStatusCode.OK, redacoes.ToList(), "As redações foram encontradas com este filtro. ", responsePaginacao);
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
