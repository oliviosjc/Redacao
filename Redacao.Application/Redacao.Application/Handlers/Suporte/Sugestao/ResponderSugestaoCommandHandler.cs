using MediatR;
using Redacao.Application.Commands.Suporte.Sugestao;
using Redacao.Application.DTOs;
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
    public class ResponderSugestaoCommandHandler : IRequestHandler<ResponderSugestaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<SugestaoSugestao> _repositorioSugestao;

        public ResponderSugestaoCommandHandler(IRepositorioGenerico<SugestaoSugestao> repositorioSugestao)
        {
            _repositorioSugestao = repositorioSugestao;
        }

        public async Task<ResponseViewModel<string>> Handle(ResponderSugestaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sugestao = await _repositorioSugestao.Get(wh => wh.Id == request.Id
                                                              && wh.Ativo);

                if (sugestao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A sugestão que deseja responder não existe na base de dados.");

                if(sugestao.Status != StatusSugestaoEnum.AGUARDANDO_RESPOSTA_SYSADMIN)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A sugestão que deseja responder já foi respondida.");

                sugestao.SetarResposta(request.Resposta);

                await _repositorioSugestao.Update(sugestao);
                await _repositorioSugestao.Save();

                _repositorioSugestao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A sugestão foi respondida com sucesso. O autor irá receber uma notificação :)");
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
