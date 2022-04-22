using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Categoria;
using Redacao.Domain.Entidades.Categoria;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Categoria
{
    public class BuscarTodasCategoriasQueryHandler : IRequestHandler<BuscarTodasCategoriasQuery, ResponseViewModel<List<CategoriaCategoria>>>
    {
        private readonly IRepositorioGenerico<CategoriaCategoria> _repositorioCategoria;

        public BuscarTodasCategoriasQueryHandler(IRepositorioGenerico<CategoriaCategoria> repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ResponseViewModel<List<CategoriaCategoria>>> Handle(BuscarTodasCategoriasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categorias = await _repositorioCategoria.GetAll(wh => wh.Ativo, null, 
                                                                    request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, 
                                                                    request.Paginacao.OrdernarDecrescente);
                                                           

                if (!categorias.Any())
                    return ResponseReturnHelper<List<CategoriaCategoria>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma categoria na base de dados :/ Tente novamente.");

                return ResponseReturnHelper<List<CategoriaCategoria>>.GerarRetorno(HttpStatusCode.OK, "As categorias foram encontradas com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<CategoriaCategoria>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<CategoriaCategoria>>.GerarRetorno(ex);
            }
        }
    }
}
