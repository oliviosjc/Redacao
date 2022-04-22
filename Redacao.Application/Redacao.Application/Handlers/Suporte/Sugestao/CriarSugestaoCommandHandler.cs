using MediatR;
using Redacao.Application.Commands.Suporte.Sugestao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using Redacao.Domain.Enums.Suporte.Sugestao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Suporte.Sugestao
{
    public class CriarSugestaoCommandHandler : IRequestHandler<CriarSugestaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public CriarSugestaoCommandHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao,
                                           UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioSugestao = repositorioSugestao;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarSugestaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestao = new SugestaoSugestao(request.Tipo, StatusSugestaoEnum.CRIADA, request.Descricao, null ,0, _usuarioLogado.Id, DateTime.UtcNow, null, true);

                var sugestaoValida = await sugestao.ValidaObjeto(sugestao);

                if(!sugestaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(sugestaoValida);

                await _repositorioSugestao.Create(sugestao);
                await _repositorioSugestao.Save();

                _repositorioSugestao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A sua sugestão foi cadastrada com sucesso. Nosso time de suporte já está avaliando sua sugestão. Obrigado por fazer a nossa plataforma melhor :)");
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
