using FluentValidation;
using Redacao.Domain.Entidades.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Organizacao
{
    public class OrganizacaoValidacao : AbstractValidator<OrganizacaoOrganizacao>
    {
        public OrganizacaoValidacao()
        {
            RuleFor(r => r.Nome).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(r => r.Descricao).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(r => r.CodigoExterno).NotNull().NotEmpty();
            RuleFor(r => r.CorPrimaria).NotNull().NotEmpty().MaximumLength(8);
            RuleFor(r => r.CorSecundaria).NotEmpty().NotNull().MaximumLength(8);
            RuleFor(r => r.TipoOrganizacao).NotNull().NotEmpty().IsInEnum();
        }
    }
}
