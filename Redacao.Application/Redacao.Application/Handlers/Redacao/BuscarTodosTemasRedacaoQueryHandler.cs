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
    public class BuscarTodosTemasRedacaoQueryHandler : IRequestHandler<BuscarTodosTemasRedacaoQuery, ResponseViewModel<List<TemaRedacao>>>
    {
        private readonly IRepositorioGenerico<TemaRedacao> _repositorioTemaRedacao;

        public BuscarTodosTemasRedacaoQueryHandler(IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao)
        {
            _repositorioTemaRedacao = repositorioTemaRedacao;
        }

        public async Task<ResponseViewModel<List<TemaRedacao>>> Handle(BuscarTodosTemasRedacaoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var temas = await _repositorioTemaRedacao.GetAll(wh => wh.Ativo, null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if (!temas.Any())
                    return ResponseReturnHelper<List<TemaRedacao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhum tema na base de dados. Tente novamente com outros filtros!");

                var totalTemas = await _repositorioTemaRedacao.Count();

                ResponsePaginacao responsePaginacao = new ResponsePaginacao
                {
                    TotalPaginas = totalTemas / request.Paginacao.TamanhoPagina,
                    TotalRegistros = totalTemas,
                    TamanhoPagina = request.Paginacao.TamanhoPagina,
                    NumeroPagina = request.Paginacao.NumeroPagina
                };

                return ResponseReturnHelper<List<TemaRedacao>>.GerarRetorno(HttpStatusCode.OK, temas.ToList(), "Os temas foram encontradas com este filtro. ", responsePaginacao);
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<TemaRedacao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<TemaRedacao>>.GerarRetorno(ex);
            }
        }
    }
}
