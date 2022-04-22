using MediatR;
using Redacao.Application.Commands.Suporte.Sugestao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Suporte.Sugestao
{
    public class EditarSugestaoCommandHandler : IRequestHandler<EditarSugestaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public EditarSugestaoCommandHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao,
                                            UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioSugestao = repositorioSugestao;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarSugestaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestao = await _repositorioSugestao.Get(wh => wh.Id == request.Id
                                                              && wh.Ativo);

                if(sugestao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A sugestão que deseja editar não existe na base de dados.");

                sugestao = new SugestaoSugestao(request.Tipo, sugestao.Status, request.Descricao, null ,sugestao.Id, sugestao.UsuarioCriadorId, sugestao.CriadoEm, DateTime.UtcNow, true);

                var sugestaoValida = await sugestao.ValidaObjeto(sugestao);

                if(!sugestaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(sugestaoValida);

                await _repositorioSugestao.Update(sugestao);
                await _repositorioSugestao.Save();

                _repositorioSugestao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A sugestão foi editada com sucesso.");
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
