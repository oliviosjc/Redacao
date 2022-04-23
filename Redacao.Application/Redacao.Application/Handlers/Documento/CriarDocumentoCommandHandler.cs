using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Redacao.Application.Commands.Documento;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Application.Exceptions;
using Redacao.Application.Helpers;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Repositorios;
using Redacao.Infra.Cloud.Azure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redacao.Application.Handlers.Documento
{
    public class CriarDocumentoCommandHandler : IRequestHandler<CriarDocumentoCommand, ResponseViewModel<DocumentoDocumento>>
    {
        private readonly IRepositorioGenerico<DocumentoDocumento> _repositorioDocumento;
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        private readonly UsuarioLogadoMiddlewareModel _usuarioLogado;

        public CriarDocumentoCommandHandler(IRepositorioGenerico<DocumentoDocumento> repositorioDocumento,
                                            IAzureBlobStorageService azureBlobStorageService,
                                            UsuarioLogadoMiddlewareModel usuarioLogado)
        {
            _repositorioDocumento = repositorioDocumento;
            _azureBlobStorageService = azureBlobStorageService;
            _usuarioLogado = usuarioLogado;
        }

        public async Task<ResponseViewModel<DocumentoDocumento>> Handle(CriarDocumentoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var documentoCloud = await _azureBlobStorageService.CriarDocumento(request.Arquivo);

                var documento = new DocumentoDocumento(documentoCloud.NomeArquivo, documentoCloud.NomeArquivoCloud, documentoCloud.Extensao, 
                                                       documentoCloud.Tamanho, request.Tipo, request.ChaveValor , 0, _usuarioLogado.Id, 
                                                       DateTime.Now, null, true);

                var documentoValido = await documento.ValidaObjeto(documento);

                if (!documentoValido.IsValid)
                    return ResponseReturnHelper<DocumentoDocumento>.GerarRetorno(documentoValido);

                await _repositorioDocumento.Create(documento);
                await _repositorioDocumento.Save();

                _repositorioDocumento.Dispose();
                return ResponseReturnHelper<DocumentoDocumento>.GerarRetorno(HttpStatusCode.OK, "O documento foi gerado com sucesso.");
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
