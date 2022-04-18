using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class CriarUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string NumeroCelular { get; set; }

        public string Senha { get; set; }

        public string RepetirSenha { get; set; }

        public Guid CodigoExterno { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }
    }
}
