using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Redacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class BuscarRedacaoPorIdQueryHandler : IRequestHandler<BuscarRedacaoPorIdQuery, ResponseViewModel<RedacaoRedacao>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;

        public BuscarRedacaoPorIdQueryHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao)
        {
            _repositorioRedacao = repositorioRedacao;
        }

        public async Task<ResponseViewModel<RedacaoRedacao>> Handle(BuscarRedacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var redacao = await _repositorioRedacao.Get(wh => wh.Ativo
                                                                    && wh.Id == request.Id);

                if (redacao is null)
                    return ResponseReturnHelper<RedacaoRedacao>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma redação com este ID :( Tente novamente.");

                return ResponseReturnHelper<RedacaoRedacao>.GerarRetorno(HttpStatusCode.OK, redacao, "A redação foi encontrada com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<RedacaoRedacao>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<RedacaoRedacao>.GerarRetorno(ex);
            }
        }
    }
}
