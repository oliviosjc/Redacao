using FluentValidation;
using Redacao.Domain.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Documento
{
    public class DocumentoValidacao : AbstractValidator<DocumentoDocumento>
    {
        public DocumentoValidacao()
        {
            RuleFor(r => r.NomeOriginal).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(r => r.NomeInternoAzure).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(r => r.Extensao).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(r => r.Tamanho).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(r => r.ChaveValor).NotNull().NotEmpty();
        }
    }
}
