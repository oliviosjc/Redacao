using FluentValidation;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Vestibular
{
    public class VestibularValidacao : AbstractValidator<VestibularVestibular>
    {
        public VestibularValidacao()
        {
            RuleFor(r => r.Nome).NotNull().NotEmpty().MaximumLength(255);
            RuleFor(r => r.Descricao).NotNull().NotEmpty().MaximumLength(255);
        }
    }
}
