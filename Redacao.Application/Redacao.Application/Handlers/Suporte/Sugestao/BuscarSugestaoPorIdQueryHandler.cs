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
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Suporte.Sugestao
{
    public class BuscarSugestaoPorIdQueryHandler : IRequestHandler<BuscarSugestaoPorIdQuery, ResponseViewModel<SugestaoSugestao>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public BuscarSugestaoPorIdQueryHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao,
                                               UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioSugestao = repositorioSugestao;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<SugestaoSugestao>> Handle(BuscarSugestaoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestao = await _repositorioSugestao.Get(wh => wh.Ativo 
                                                             && wh.Id == request.Id
                                                             && _usuarioLogado.EAdministrador == false ? wh.UsuarioCriadorId == _usuarioLogado.Id : true);

                if (sugestao is null)
                    return ResponseReturnHelper<SugestaoSugestao>.GerarRetorno(HttpStatusCode.BadRequest, "Não foi encontrada nenhuma sugestão sua na base de dados com este Id ou você não possui permissão para visualizar.");


                return ResponseReturnHelper<SugestaoSugestao>.GerarRetorno(HttpStatusCode.OK, sugestao, "A sugestão foi encontrada com sucesso.");

            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<SugestaoSugestao>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<SugestaoSugestao>.GerarRetorno(ex);
            }
        }
    }
}
