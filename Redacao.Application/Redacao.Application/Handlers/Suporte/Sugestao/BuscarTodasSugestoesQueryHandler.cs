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
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Suporte.Sugestao
{
    public class BuscarTodasSugestoesQueryHandler : IRequestHandler<BuscarTodasSugestoesQuery, ResponseViewModel<List<SugestaoSugestao>>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;

        public BuscarTodasSugestoesQueryHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao)
        {
            _repositorioSugestao = repositorioSugestao;
        }

        public async Task<ResponseViewModel<List<SugestaoSugestao>>> Handle(BuscarTodasSugestoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestoes = await _repositorioSugestao.GetAll(wh => wh.Ativo,
                                                                  null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if(!sugestoes.Any())
                    return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(HttpStatusCode.NoContent, "Nenhuma sugestão foi encontrada na base de dados.");

                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(HttpStatusCode.OK, sugestoes.ToList() ,"As sugestões foram encontradas na base de dados.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<SugestaoSugestao>>.GerarRetorno(ex);
            }
        }
    }
}
