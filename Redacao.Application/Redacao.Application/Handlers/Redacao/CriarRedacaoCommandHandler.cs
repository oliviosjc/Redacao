using MediatR;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
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
    public class CriarRedacaoCommandHandler : IRequestHandler<CriarRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<RedacaoRedacao> _repositorioRedacao;
        private readonly IRepositorioGenerico<VestibularTema> _repositorioVestibularTema;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public CriarRedacaoCommandHandler(IRepositorioGenerico<RedacaoRedacao> repositorioRedacao,
                                          IRepositorioGenerico<VestibularTema> repositorioVestibularTema,
                                          UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioRedacao = repositorioRedacao;
            _repositorioVestibularTema = repositorioVestibularTema;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibularTema = await _repositorioVestibularTema.Get(wh => wh.TemaId == request.TemaRedacaoId
                                                                          && wh.VestibularId == request.VestibularId);

                if (vestibularTema is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O vinculo deste tema para este vestibular não existe. Tente novamente!");

                var redacao = new RedacaoRedacao(request.Descricao, request.TemaRedacaoId, request.VestibularId, 
                                                 _usuarioLogado.Id, null, TipoRedacaoEnum.DEFAULT, StatusRedacaoEnum.CRIADA,
                                                 0, _usuarioLogado.Id, DateTime.UtcNow, null, true);

                var redacaoValida = await redacao.ValidaObjeto(redacao);

                if(!redacaoValida.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(redacaoValida);

                await _repositorioRedacao.Create(redacao);
                await _repositorioRedacao.Save();

                _repositorioRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooba! O cabeçalho da sua redação foi criada com sucesso. Agora, preenche os próximos passos para conclui-lá e receber a correção :)");
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
