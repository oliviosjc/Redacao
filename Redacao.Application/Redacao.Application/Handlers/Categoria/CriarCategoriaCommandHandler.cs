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
    public class CriarCategoriaCommandHandler : IRequestHandler<CriarCategoriaCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<CategoriaCategoria> _repositorioCategoria;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;
        public CriarCategoriaCommandHandler(IRepositorioGenerico<CategoriaCategoria> repositorioCategoria,
                                            UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioCategoria = repositorioCategoria;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarCategoriaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoria = await _repositorioCategoria.Get(wh => wh.Nome.ToUpper() == request.Nome
                                                                && wh.Ativo
                                                                && wh.TipoCategoria == request.TipoCategoria);

                if(categoria != null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Já existe uma categoria com este nome :/ Tente novamente.");

                categoria = new CategoriaCategoria(request.Nome, request.TipoCategoria, 0, _usuarioLogado.Id, DateTime.UtcNow, null, true);

                var categoriaValida = await categoria.ValidaObjeto(categoria);

                if(!categoriaValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(categoriaValida);

                await _repositorioCategoria.Create(categoria);
                await _repositorioCategoria.Save();

                _repositorioCategoria.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A categoria foi criada com sucesso.");
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
