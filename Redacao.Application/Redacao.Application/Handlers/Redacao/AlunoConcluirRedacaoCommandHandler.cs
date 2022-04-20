using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Application.Notifications.Redacao;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Enums.Redacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class AlunoConcluirRedacaoCommandHandler : IRequestHandler<AlunoConcluirRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;
        private readonly IMediator _mediator;

        public AlunoConcluirRedacaoCommandHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao,
                                                  IMediator mediator)
        {
            _repositorioRedacao = repositorioRedacao;
            _mediator = mediator;
        }

        public async Task<ResponseViewModel<string>> Handle(AlunoConcluirRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var redacao = await _repositorioRedacao.Get(wh => wh.Ativo
                                                            && wh.Id == request.Id
                                                            && wh.StatusRedacao == StatusRedacaoEnum.CRIADA);

                if(redacao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Nenhuma redação com status CRIADA foi encontrada com este Id na base de dados :/ Tente novamente.");

                redacao = new RedacaoRedacao(redacao.Descricao, redacao.TemaRedacaoId, redacao.VestibularId, 
                                             redacao.UsuarioAlunoId, redacao.ProfessorResponsavelId, redacao.TipoRedacao,
                                             StatusRedacaoEnum.AGUARDANDO_PROFESSOR, redacao.Id, redacao.UsuarioCriadorId, 
                                             redacao.CriadoEm, DateTime.UtcNow, true);

                var redacaoValida = await redacao.ValidaObjeto(redacao);

                if(!redacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(redacaoValida);

                await _repositorioRedacao.Update(redacao);
                await _repositorioRedacao.Save();

                await _mediator.Publish(new AlunoConcluirRedacaoNotification(request));

                _repositorioRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "A redação foi concluída com sucesso. Aguarde a correção de um dos nossos professores :)");
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
