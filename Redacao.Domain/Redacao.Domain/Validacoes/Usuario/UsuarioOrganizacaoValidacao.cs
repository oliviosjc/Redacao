using FluentValidation;
using Redacao.Domain.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Usuario
{
    public class UsuarioOrganizacaoValidacao : AbstractValidator<UsuarioOrganizacao>
    {
        public UsuarioOrganizacaoValidacao()
        {
            RuleFor(r => r.UsuarioId).NotNull().NotEmpty();
            RuleFor(r => r.OrganizacaoId).NotNull().NotEmpty();
        }
    }
}
