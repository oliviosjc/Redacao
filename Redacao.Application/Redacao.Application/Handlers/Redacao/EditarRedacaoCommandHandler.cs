using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Entidades.Vestibular;
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
    public class EditarRedacaoCommandHandler : IRequestHandler<EditarRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;
        private readonly IRepositorioGenerico<VestibularTema> _repositorioVestibularTema;

        public EditarRedacaoCommandHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao,
                                           IRepositorioGenerico<VestibularTema> repositorioVestibularTema)
        {
            _repositorioRedacao = repositorioRedacao;
            _repositorioVestibularTema = repositorioVestibularTema;
        }

        public async Task<ResponseViewModel<string>> Handle(EditarRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var redacao = await _repositorioRedacao.Get(wh => wh.Ativo
                                                            && wh.Id == request.Id);

                if (redacao.StatusRedacao != StatusRedacaoEnum.CRIADA || redacao.StatusRedacao != StatusRedacaoEnum.AGUARDANDO_PROFESSOR)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não é possível realizar mais alterações. A correção já se encontra em correção com o professor ou em outra etapa final.");

                var vestibularTema = _repositorioVestibularTema.Get(wh => wh.Ativo 
                                                                    && wh.TemaId == request.TemaRedacaoId 
                                                                    && wh.VestibularId == request.VestibularId);

                if(vestibularTema is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Não existe nenhum vinculo para este tema com este vestibular. Tente novamente");

                redacao = new RedacaoRedacao(request.Descricao, request.TemaRedacaoId, request.VestibularId, 
                                             redacao.UsuarioAlunoId, null, TipoRedacaoEnum.DEFAULT, 
                                             redacao.StatusRedacao, redacao.Id, redacao.UsuarioCriadorId, 
                                             redacao.CriadoEm, DateTime.UtcNow, true);

                var redacaoValida = await redacao.ValidaObjeto(redacao);

                if(!redacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(redacaoValida);

                await _repositorioRedacao.Update(redacao);
                await _repositorioRedacao.Save();

                _repositorioRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooba. Redação editada com sucesso :)");
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
