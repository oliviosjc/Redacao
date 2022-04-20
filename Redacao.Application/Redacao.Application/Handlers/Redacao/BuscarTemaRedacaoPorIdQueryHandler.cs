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
    public class BuscarTemaRedacaoPorIdQueryHandler : IRequestHandler<BuscarTemaRedacaoPorIdQuery, ResponseViewModel<TemaRedacao>>
    {
        private readonly IRepositorioGenerico<TemaRedacao> _repositorioTemaRedacao;

        public BuscarTemaRedacaoPorIdQueryHandler(IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao)
        {
            _repositorioTemaRedacao = repositorioTemaRedacao;
        }
        
        public async Task<ResponseViewModel<TemaRedacao>> Handle(BuscarTemaRedacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tema = await _repositorioTemaRedacao.Get(wh => wh.Ativo
                                                                    && wh.Id == request.Id);

                if (tema is null)
                    return ResponseReturnHelper<TemaRedacao>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhum tema de redação com este ID :( Tente novamente.");

                return ResponseReturnHelper<TemaRedacao>.GerarRetorno(HttpStatusCode.OK, tema, "O tema de redação foi encontrada com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<TemaRedacao>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<TemaRedacao>.GerarRetorno(ex);
            }
        }
    }
}
