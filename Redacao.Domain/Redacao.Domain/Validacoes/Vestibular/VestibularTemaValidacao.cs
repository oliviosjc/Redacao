using FluentValidation;
using Redacao.Domain.Entidades.Vestibular;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Vestibular
{
    public class VestibularTemaValidacao : AbstractValidator<VestibularTema>
    {
        public VestibularTemaValidacao()
        {
            RuleFor(r => r.TemaId).NotNull().NotEmpty();
            RuleFor(r => r.VestibularId).NotNull().NotEmpty();
        }
    }
}
