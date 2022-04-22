using MediatR;
using Redacao.Application.Commands.Categoria;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
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
    public class EditarCategoriaCommandHandler : IRequestHandler<EditarCategoriaCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<CategoriaCategoria> _repositorioCategoria;

        public EditarCategoriaCommandHandler(IRepositorioGenerico<CategoriaCategoria> repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaExistente = await _repositorioCategoria.Get(wh => wh.Nome.ToUpper() == request.Nome
                                                                && wh.Ativo
                                                                && wh.TipoCategoria == request.TipoCategoria
                                                                && wh.Id != request.Id);

                if (categoriaExistente != null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Já existe uma categoria com este nome :/ Tente novamente.");

                var categoria = await _repositorioCategoria.Get(wh => wh.Ativo
                                                                && wh.Id == request.Id);

                if (categoriaExistente != null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não existe uma categoria com este Id na base de dados.");

                categoria = new CategoriaCategoria(request.Nome, request.TipoCategoria, categoria.Id, categoria.UsuarioCriadorId, categoria.CriadoEm, DateTime.UtcNow, true);

                var categoriaValida = await categoria.ValidaObjeto(categoria);

                if (!categoriaValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(categoriaValida);

                await _repositorioCategoria.Update(categoria);
                await _repositorioCategoria.Save();

                _repositorioCategoria.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A categoria foi editada com sucesso.");
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
