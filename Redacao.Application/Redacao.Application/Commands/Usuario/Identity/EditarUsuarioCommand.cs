using MediatR;
using Redacao.Application.DTOs;
using Redacao.Domain.Enums.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Usuario.Identity
{
    public class EditarUsuarioCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarUsuarioCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }

        public string CEP { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public UsuarioSexoEnum? Sexo { get; set; }

        public UsuarioComoConheceuEnum? ComoConheceu { get; set; }
    }
}
