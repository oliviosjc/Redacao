using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Redacao.Application.Commands.Documento;
using Redacao.Application.Commands.Redacao;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Redacao
{
    public class InserirDocumentoTemaCommandHandler : IRequestHandler<InserirDocumentoTemaCommand, ResponseViewModel<DocumentoDocumento>>
    {
        private IMediator _mediator;
        private readonly IRepositorioGenerico<TemaRedacao> _repositorioTemaRedacao;

        public InserirDocumentoTemaCommandHandler(IMediator mediator,
                                                  IRepositorioGenerico<TemaRedacao> repositorioTemaRedacao)
        {
            _mediator = mediator;
            _repositorioTemaRedacao = repositorioTemaRedacao;
        }

        public async Task<ResponseViewModel<DocumentoDocumento>> Handle(InserirDocumentoTemaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tema = await _repositorioTemaRedacao.Get(wh => wh.Ativo
                                                             && wh.Id == request.TemaId);

                if (tema is null)
                    return ResponseReturnHelper<DocumentoDocumento>.GerarRetorno(HttpStatusCode.BadRequest, "O id de tema informado não existe na base de dados.");

                var criarDocumentoCommand = new CriarDocumentoCommand
                {
                    Arquivo = request.Arquivo,
                    RedacaoId = null,
                    TemaId = request.TemaId
                };

                var resultado = await _mediator.Send(criarDocumentoCommand);

                return resultado;
            }
            catch (HandlerException ex)
            {
                return ResponseReturnHelper<DocumentoDocumento>.GerarRetorno(ex);
            }
            catch (SQLException ex)
            {
                return ResponseReturnHelper<DocumentoDocumento>.GerarRetorno(ex);
            }
        }
    }
}
