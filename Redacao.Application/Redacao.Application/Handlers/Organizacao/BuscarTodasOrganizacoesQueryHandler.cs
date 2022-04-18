using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Organizacao;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Organizacao
{
    public class BuscarTodasOrganizacoesQueryHandler : IRequestHandler<BuscarTodasOrganizacoesQuery, ResponseViewModel<List<OrganizacaoOrganizacao>>>
    {
        private readonly IRepositorioGenerico<OrganizacaoOrganizacao> _repositorioOrganizacao;
        public BuscarTodasOrganizacoesQueryHandler(IRepositorioGenerico<OrganizacaoOrganizacao> repositorioOrganizacao)
        {
            _repositorioOrganizacao = repositorioOrganizacao;
        }

        public async Task<ResponseViewModel<List<OrganizacaoOrganizacao>>> Handle(BuscarTodasOrganizacoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacoes = await _repositorioOrganizacao.GetAll(wh => wh.Ativo, null, request.Paginacao.NumeroPagina, request.Paginacao.TamanhoPagina, request.Paginacao.OrdernarDecrescente);

                if (!organizacoes.Any())
                    return ResponseReturnHelper<List<OrganizacaoOrganizacao>>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhuma organizações na base de dados. Tente novamente com outros filtros!");

                var totalOrganizacoes = await _repositorioOrganizacao.Count();

                ResponsePaginacao responsePaginacao = new ResponsePaginacao
                {
                    TotalPaginas = totalOrganizacoes / request.Paginacao.TamanhoPagina,
                    TotalRegistros = totalOrganizacoes,
                    TamanhoPagina = request.Paginacao.TamanhoPagina,
                    NumeroPagina = request.Paginacao.NumeroPagina
                };

                return ResponseReturnHelper<List<OrganizacaoOrganizacao>>.GerarRetorno(HttpStatusCode.OK, organizacoes.ToList(), "As organizações foram encontradas com este filtro. ", responsePaginacao);
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<List<OrganizacaoOrganizacao>>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<List<OrganizacaoOrganizacao>>.GerarRetorno(ex);
            }
        }
    }
}

