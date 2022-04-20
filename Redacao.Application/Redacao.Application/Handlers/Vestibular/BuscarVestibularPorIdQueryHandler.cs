using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Queries.Vestibular;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Vestibular
{
    public class BuscarVestibularPorIdQueryHandler : IRequestHandler<BuscarVestibularPorIdQuery, ResponseViewModel<VestibularVestibular>>
    {
        private readonly IRepositorioGenerico<VestibularVestibular> _repositorioVestibular;

        public BuscarVestibularPorIdQueryHandler(IRepositorioGenerico<VestibularVestibular> repositorioVestibular)
        {
            _repositorioVestibular = repositorioVestibular;
        }

        public async Task<ResponseViewModel<VestibularVestibular>> Handle(BuscarVestibularPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibular = await _repositorioVestibular.Get(wh => wh.Ativo
                                                                    && wh.Id == request.Id);

                if (vestibular is null)
                    return ResponseReturnHelper<VestibularVestibular>.GerarRetorno(HttpStatusCode.NoContent, "Não foi encontrado nenhum vestibular com este ID :( Tente novamente.");

                return ResponseReturnHelper<VestibularVestibular>.GerarRetorno(HttpStatusCode.OK, vestibular, "O vestibular foi encontrada com sucesso.");
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<VestibularVestibular>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<VestibularVestibular>.GerarRetorno(ex);
            }
        }
    }
}
