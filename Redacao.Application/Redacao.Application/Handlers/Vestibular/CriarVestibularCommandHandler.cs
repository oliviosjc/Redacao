using MediatR;
using Redacao.Application.Commands.Vestibular;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
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
    public class CriarVestibularCommandHandler : IRequestHandler<CriarVestibularCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<VestibularVestibular> _repositorioVestibular;

        public CriarVestibularCommandHandler(IRepositorioGenerico<VestibularVestibular> repositorioVestibular)
        {
            _repositorioVestibular = repositorioVestibular;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarVestibularCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibular = new VestibularVestibular(request.Nome, request.Descricao, 0, request.UsuarioLogado.Id, DateTime.UtcNow, null, true);

                var validacaoVestibular = await vestibular.ValidaObjeto(vestibular);

                if (!validacaoVestibular.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(validacaoVestibular);

                await _repositorioVestibular.Create(vestibular);
                await _repositorioVestibular.Save();

                _repositorioVestibular.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooba. Vestibular criado com sucesso!");
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
