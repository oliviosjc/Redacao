using MediatR;
using Microsoft.AspNetCore.Http;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Entidades.Documento;
using Redacao.Domain.Enums.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Documento
{
    public class CriarDocumentoCommand : IRequest<ResponseViewModel<DocumentoDocumento>>
    {
        public CriarDocumentoCommand()
        {

        }

        public CriarDocumentoCommand(IFormFile arquivo, Int32 chaveValor, TipoDocumentoEnum tipo)
        {
            this.Arquivo = arquivo;
            this.ChaveValor = chaveValor;
            this.Tipo = tipo;
        }

        public IFormFile Arquivo { get; set; }

        public Int32 ChaveValor { get; set; }

        public TipoDocumentoEnum Tipo { get; set; }
    }
}
