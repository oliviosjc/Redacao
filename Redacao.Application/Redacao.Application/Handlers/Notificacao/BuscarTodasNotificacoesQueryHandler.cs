using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Notificacao;
using Redacao.Domain.Entidades.Notificacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Notificacao
{
    public class BuscarTodasNotificacoesQueryHandler : IRequestHandler<BuscarTodasNotificacoesQuery, ResponseViewModel<List<NotificacaoNotificacao>>>
    {
        private readonly IRepositorioGenerico<NotificacaoNotificacao> _repositorioNotificacao;

        public BuscarTodasNotificacoesQueryHandler(IRepositorioGenerico<NotificacaoNotificacao> repositorioNotificacao)
        {
            _repositorioNotificacao = repositorioNotificacao;
        }

        public async Task<ResponseViewModel<List<NotificacaoNotificacao>>> Handle(BuscarTodasNotificacoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notificacoes = await _repositorioNotificacao.GetAll(wh => wh.Ativo, null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if (!notificacoes.Any())
                    return ResponseReturnHelper<List<NotificacaoNotificacao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhuma notificação na base de dados. Tente novamente com outros filtros!");

                var totalNotificacoes = await _repositorioNotificacao.Count();

                ResponsePaginacao responsePaginacao = new ResponsePaginacao
                {
                    TotalPaginas = totalNotificacoes / request.Paginacao.TamanhoPagina,
                    TotalRegistros = totalNotificacoes,
                    TamanhoPagina = request.Paginacao.TamanhoPagina,
                    NumeroPagina = request.Paginacao.NumeroPagina
                };

                return ResponseReturnHelper<List<NotificacaoNotificacao>>.GerarRetorno(HttpStatusCode.OK, notificacoes.ToList(), "As notificações foram encontradas com este filtro. ", responsePaginacao);
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<NotificacaoNotificacao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<NotificacaoNotificacao>>.GerarRetorno(ex);
            }
        }
    }
}
