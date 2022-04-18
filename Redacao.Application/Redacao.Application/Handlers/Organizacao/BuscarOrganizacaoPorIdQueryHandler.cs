using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Organizacao;
using Redacao.Domain.Entidades.Organizacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Organizacao
{
    public class BuscarOrganizacaoPorIdQueryHandler : IRequestHandler<BuscarOrganizacaoPorIdQuery, ResponseViewModel<OrganizacaoOrganizacao>>
    {
        private readonly IRepositorioGenerico<OrganizacaoOrganizacao> _repositorioOrganizacao;

        public BuscarOrganizacaoPorIdQueryHandler(IRepositorioGenerico<OrganizacaoOrganizacao> repositorioOrganizacao)
        {
            _repositorioOrganizacao = repositorioOrganizacao;
        }

        public async Task<ResponseViewModel<OrganizacaoOrganizacao>> Handle(BuscarOrganizacaoPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacao = await _repositorioOrganizacao.Get(wh => wh.Ativo
                                                                    && wh.Id == request.Id);

                if(organizacao is null)
                    return ResponseReturnHelper<OrganizacaoOrganizacao>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrada nenhuma organização com este ID :( Tente novamente.");

                return ResponseReturnHelper<OrganizacaoOrganizacao>.GerarRetorno(HttpStatusCode.OK, organizacao, "A orgnização foi encontrada com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<OrganizacaoOrganizacao>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<OrganizacaoOrganizacao>.GerarRetorno(ex);
            }
        }
    }
}
