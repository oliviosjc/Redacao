using MediatR;
using Redacao.Application.Commands;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
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
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;
        public CriarTemaRedacaoCommandHandler(IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao,
                                              IRepositorioGenerico<VestibularVestibular> repositorioVestibular,
                                              UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioTemaRedacao = repositorioTemaRedacao;
            _repositorioVestibular = repositorioVestibular;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<string>> Handle(CriarTemaRedacaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tema = new TemaRedacao(request.Nome, request.Descricao, request.CategoriaId, 0,0, 0, 
                                           _usuarioLogado.Id, DateTime.UtcNow, null, true);

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
