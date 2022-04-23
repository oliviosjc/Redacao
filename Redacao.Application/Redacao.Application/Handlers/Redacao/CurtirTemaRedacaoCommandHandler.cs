using MediatR;
using Newtonsoft.Json;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Clientes;
using Redacao.Infra.Cloud.Azure.Services.ServiceBus.Publicador;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class CurtirTemaRedacaoCommandHandler : IRequestHandler<CurtirTemaRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IMensagemPublicador _mensagemPublicador;
        public readonly UsuarioLogadoMiddlewareModel _usuarioLogado;
        private readonly ClienteFilaUsuarioCurtidas _queueClient;
        public CurtirTemaRedacaoCommandHandler(IMensagemPublicador mensagemPublicador,
                                               UsuarioLogadoMiddlewareModel usuarioLogado,
                                               ClienteFilaUsuarioCurtidas queueClient)
        {
            _mensagemPublicador = mensagemPublicador;
            _usuarioLogado = usuarioLogado;
            _queueClient = queueClient;
        }
        public async Task<ResponseViewModel<string>> Handle(CurtirTemaRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var temaRedacaoUsuarioCurtida = new TemaRedacaoUsuarioCurtida(_usuarioLogado.Id, request.TemaId, request.Curtir);

                await _mensagemPublicador.Publicar(JsonConvert.SerializeObject(temaRedacaoUsuarioCurtida), _queueClient);

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "Sua interação foi computada com sucesso. Obrigado pelo seu feedback :)");
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
