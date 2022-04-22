using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Categoria;
using Redacao.Domain.Entidades.Categoria;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Categoria
{
    public class BuscarCategoriaPorIdQueryHandler : IRequestHandler<BuscarCategoriaPorIdQuery, ResponseViewModel<CategoriaCategoria>>
    {
        private readonly IRepositorioGenerico<CategoriaCategoria> _repositorioCategoria;

        public BuscarCategoriaPorIdQueryHandler(IRepositorioGenerico<CategoriaCategoria> repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ResponseViewModel<CategoriaCategoria>> Handle(BuscarCategoriaPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _repositorioCategoria.Get(wh => wh.Ativo
                                                                && wh.Id == request.Id);

                if(categoria is null)
                    return ResponseReturnHelper<CategoriaCategoria>.GerarRetorno(HttpStatusCode.BadRequest, "A categoria com este Id não foi encontrada na base de dados.");

                return ResponseReturnHelper<CategoriaCategoria>.GerarRetorno(HttpStatusCode.OK, categoria, "A categoria foi encontrada com sucesso na base de dados.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<CategoriaCategoria>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<CategoriaCategoria>.GerarRetorno(ex);
            }
        }
    }
}
