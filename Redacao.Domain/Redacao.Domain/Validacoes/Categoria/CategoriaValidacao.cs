using FluentValidation;
using Redacao.Domain.Entidades.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Categoria
{
    public class CategoriaValidacao : AbstractValidator<CategoriaCategoria>
    {
        public CategoriaValidacao()
        {
            RuleFor(r => r.Nome).NotEmpty().NotNull().MaximumLength(255);
        }
    }
}
