using FluentValidation;
using Redacao.Domain.Entidades.Suporte.Sugestao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Suporte.Sugestao
{
    public class SugestaoValidacao : AbstractValidator<SugestaoSugestao>
    {
        public SugestaoValidacao()
        {
            RuleFor(r => r.Descricao).NotEmpty().NotNull().MaximumLength(255);
            RuleFor(r => r.Status).NotEmpty().NotNull();
            RuleFor(r => r.Tipo).NotEmpty().NotNull();
        }
    }
}
