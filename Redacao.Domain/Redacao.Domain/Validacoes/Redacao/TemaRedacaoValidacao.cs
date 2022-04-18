using FluentValidation;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Redacao
{
    public class TemaRedacaoValidacao : AbstractValidator<TemaRedacao>
    {
        public TemaRedacaoValidacao()
        {
            RuleFor(r => r.Id).NotNull();
        }
    }
}
