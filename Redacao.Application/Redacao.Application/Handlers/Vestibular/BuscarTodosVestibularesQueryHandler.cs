using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Vestibular;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Vestibular
{
    public class BuscarTodosVestibularesQueryHandler : IRequestHandler<BuscarTodosVestibularesQuery, ResponseViewModel<List<VestibularVestibular>>>
    {
        private readonly IRepositorioGenerico<VestibularVestibular> _repositorioVestibular;

        public BuscarTodosVestibularesQueryHandler(IRepositorioGenerico<VestibularVestibular> repositorioVestibular)
        {
            _repositorioVestibular = repositorioVestibular;
        }

        public async Task<ResponseViewModel<List<VestibularVestibular>>> Handle(BuscarTodosVestibularesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibulares = await _repositorioVestibular.GetAll(wh => wh.Ativo, null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if (!vestibulares.Any())
                    return ResponseReturnHelper<List<VestibularVestibular>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhum vestibular na base de dados. Tente novamente com outros filtros!");

                var totalVestibulares = await _repositorioVestibular.Count();

                ResponsePaginacao responsePaginacao = new ResponsePaginacao
                {
                    TotalPaginas = totalVestibulares / request.Paginacao.TamanhoPagina,
                    TotalRegistros = totalVestibulares,
                    TamanhoPagina = request.Paginacao.TamanhoPagina,
                    NumeroPagina = request.Paginacao.NumeroPagina
                };

                return ResponseReturnHelper<List<VestibularVestibular>>.GerarRetorno(HttpStatusCode.OK, vestibulares.ToList(), "Os vestibulares foram encontradas com este filtro. ", responsePaginacao);
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<VestibularVestibular>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<VestibularVestibular>>.GerarRetorno(ex);
            }
        }
    }
}
