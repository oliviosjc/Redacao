using FluentValidation;
using Redacao.Domain.Entidades.Usuario;
using Redacao.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Usuario.Identity
{
    public class UsuarioValidacao : AbstractValidator<UsuarioUsuario>
    {
        public UsuarioValidacao()
        {
            RuleFor(r => r.QuantidadeCorrecoesDisponiveis).NotNull().NotEmpty();

            RuleFor(r => r.RG).NotEmpty().NotNull().MaximumLength(9);

            RuleFor(r => r.CPF).NotEmpty().NotNull().MaximumLength(11).Custom((cpf, context) =>
            {
                if (!DocumentoUtil.ValidarCPF(cpf))
                    context.AddFailure("O 'CPF' é inválido.");
            });

            RuleFor(r => r.CNPJ).NotEmpty().NotNull().MaximumLength(14).Custom((cnpj, context) =>
            {
                if (!DocumentoUtil.ValidarCNPJ(cnpj))
                    context.AddFailure("O 'CNPJ' é inválido.");
            });

            RuleFor(r => r.Email).NotNull().MaximumLength(50);
            RuleFor(r => r.PhoneNumber).NotNull().MaximumLength(13);
            RuleFor(r => r.TipoUsuario).NotNull().NotEmpty().IsInEnum();
            RuleFor(r => r.NormalizedEmail).NotNull().NotEmpty();
            RuleFor(r => r.NormalizedUserName).NotNull().NotEmpty();
            RuleFor(r => r.Nome).NotNull().NotEmpty().MaximumLength(128);
            RuleFor(r => r.CNPJ).NotNull().NotEmpty().When(wh => string.IsNullOrEmpty(wh.RG) && string.IsNullOrEmpty(wh.CPF));
            RuleFor(r => r.RG).NotNull().NotEmpty().When(wh => string.IsNullOrEmpty(wh.CNPJ) && string.IsNullOrEmpty(wh.CPF));
            RuleFor(r => r.CPF).NotNull().NotEmpty().When(wh => string.IsNullOrEmpty(wh.CNPJ) && string.IsNullOrEmpty(wh.RG));
        }
    }
}
