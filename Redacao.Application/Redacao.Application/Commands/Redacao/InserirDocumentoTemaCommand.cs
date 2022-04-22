using MediatR;
using Microsoft.AspNetCore.Http;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class InserirDocumentoTemaCommand : IRequest<ResponseViewModel<DocumentoDocumento>>
    {
        public InserirDocumentoTemaCommand()
        {

        }

        public InserirDocumentoTemaCommand(Int32 temaId, IFormFile arquivo)
        {
            this.Arquivo = arquivo;
            this.TemaId = temaId;
        }

        public IFormFile Arquivo { get; set; }

        public Int32 TemaId { get; set; }
    }
}
