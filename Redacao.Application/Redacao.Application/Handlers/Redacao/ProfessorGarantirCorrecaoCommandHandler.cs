using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
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
    public class ProfessorGarantirCorrecaoCommandHandler : IRequestHandler<ProfessorGarantirCorrecaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;

        public ProfessorGarantirCorrecaoCommandHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao)
        {
            _repositorioRedacao = repositorioRedacao;
        }

        public async Task<ResponseViewModel<string>> Handle(ProfessorGarantirCorrecaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var redacao = await _repositorioRedacao.Get(wh => wh.Id == request.Id
                                                            && wh.Ativo);

                if (redacao is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "Nenhuma correção com este Id foi encontrada na base de dados :/ Tente novamente.");

                if (redacao.StatusRedacao != StatusRedacaoEnum.AGUARDANDO_PROFESSOR)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "A redação não pode ser garantida por este professor, pois já se encontra em outro status :/ Tente novamente.");

                redacao = new RedacaoRedacao(redacao.Descricao, redacao.TemaRedacaoId, redacao.VestibularId,
                                             redacao.UsuarioAlunoId, request.UsuarioLogado.Id, redacao.TipoRedacao,
                                             StatusRedacaoEnum.COM_O_PROFESSOR, redacao.Id, redacao.UsuarioCriadorId,
                                             redacao.CriadoEm, DateTime.UtcNow, true);

                var redacaoValida = await redacao.ValidaObjeto(redacao);

                if (!redacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(redacaoValida);

                await _repositorioRedacao.Update(redacao);
                await _repositorioRedacao.Save();

                _repositorioRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "Parabéns professor! Você garantiu essa redação para a sua correção. Você tem 4 horas para iniciar ou a mesma retornará a fila.");
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
