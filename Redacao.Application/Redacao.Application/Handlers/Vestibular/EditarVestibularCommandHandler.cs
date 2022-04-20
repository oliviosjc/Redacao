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
    public class EditarVestibularCommandHandler : IRequestHandler<EditarVestibularCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<VestibularVestibular> _repositorioVestibular;

        public EditarVestibularCommandHandler(IRepositorioGenerico<VestibularVestibular> repositorioVestibular)
        {
            _repositorioVestibular = repositorioVestibular;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarVestibularCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibular = await _repositorioVestibular.Get(wh => wh.Ativo
                                                                  && wh.Id == request.Id);

                if (vestibular is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Nenhum vestibular foi encontrado na base de dados com este Id. Tente novamente.");

                vestibular = new VestibularVestibular(request.Nome, request.Descricao, vestibular.Id, request.UsuarioLogado.Id, vestibular.CriadoEm, DateTime.UtcNow, true);

                var validacaoVestibular = await vestibular.ValidaObjeto(vestibular);

                if (!validacaoVestibular.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(validacaoVestibular);

                await _repositorioVestibular.Update(vestibular);
                await _repositorioVestibular.Save();

                _repositorioVestibular.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooba. Vestibular editado com sucesso!");
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
