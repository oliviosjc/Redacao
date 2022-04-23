using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
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
    public class EditarTemaRedacaoCommandHandler : IRequestHandler<EditarTemaRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<TemaRedacao> _repositorioTemaRedacao;

        public EditarTemaRedacaoCommandHandler(IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao)
        {
            _repositorioTemaRedacao = repositorioTemaRedacao;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarTemaRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tema = await _repositorioTemaRedacao.Get(wh => wh.Ativo
                                                             && wh.Id == request.Id);

                if (tema is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O tema que deseja editar não existe ou você não possui direitos para acessa-la :/");

                tema = new TemaRedacao(request.Nome, request.Descricao, request.CategoriaId, 0,0 ,request.Id, tema.UsuarioCriadorId ,tema.CriadoEm, DateTime.UtcNow, true);

                var temaValido = await tema.ValidaObjeto(tema);

                if (!temaValido.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(temaValido);

                await _repositorioTemaRedacao.Update(tema);
                await _repositorioTemaRedacao.Save();

                _repositorioTemaRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooooba... As informações de cabeçalho do tema foram editadas com sucesso :)");
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
