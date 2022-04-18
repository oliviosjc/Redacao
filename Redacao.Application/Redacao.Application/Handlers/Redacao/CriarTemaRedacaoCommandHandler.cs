using MediatR;
using Redacao.Application.Commands;
using Redacao.Application.DTOs;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Entidades.Vestibular;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class CriarTemaRedacaoCommandHandler : IRequestHandler<CriarTemaRedacaoCommand, ResponseViewModel<string>>
    {
        private readonly IRepositorioGenerico<TemaRedacao> _repositorioTemaRedacao;
        private readonly IRepositorioGenerico<VestibularVestibular> _repositorioVestibular;

        public CriarTemaRedacaoCommandHandler(IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao,
                                              IRepositorioGenerico<VestibularVestibular> repositorioVestibular)
        {
            _repositorioTemaRedacao = repositorioTemaRedacao;
            _repositorioVestibular = repositorioVestibular;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarTemaRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var vestibular = await _repositorioVestibular.Get(wh => wh.Id == request.VestibularId 
                                                            && wh.Ativo 
                                                            && wh.OrganizacaoId == request.UsuarioLogado.OrganizacaoId);

                if(vestibular is null)
                    return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.BadRequest, "O vestibular que deseja vincular ao tema não existe ou você não possui direitos para acessa-lo :/");

                var tema = new TemaRedacao(0, request.Nome, request.Descricao, request.UsuarioLogado.OrganizacaoId, request.VestibularId, AcaoEntidadeEnum.CADASTRO, request.UsuarioLogado.Id);

                var temaValido = await tema.ValidaObjeto(tema);

                if(!temaValido.IsValid)
                    return ResponseReturnHelper<string>.GerarRetorno(temaValido);

                await _repositorioTemaRedacao.Create(tema);
                await _repositorioTemaRedacao.Save();

                _repositorioTemaRedacao.Dispose();

                return ResponseReturnHelper<string>.GerarRetorno(HttpStatusCode.OK, "ooooooba... O tema de redação foi criado com sucesso :)");
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
