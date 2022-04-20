using FluentValidation;
using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Domain.Validacoes.Redacao
{
    public class RedacaoValidacao : AbstractValidator<RedacaoRedacao>
    {
        public RedacaoValidacao()
        {
            RuleFor(r => r.Descricao).NotEmpty().NotNull();
            RuleFor(r => r.TemaRedacaoId).NotEmpty().NotNull();
            RuleFor(r => r.VestibularId).NotEmpty().NotNull();
            RuleFor(r => r.UsuarioAlunoId).NotEmpty().NotNull();
            RuleFor(r => r.TipoRedacao).NotEmpty().NotNull().IsInEnum();
            RuleFor(r => r.StatusRedacao).NotEmpty().NotNull().IsInEnum();
        }
    }
}
