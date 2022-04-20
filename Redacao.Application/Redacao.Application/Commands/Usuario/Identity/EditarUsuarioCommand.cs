using MediatR;
using Redacao.Application.DTOs;
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

        public string RG { get; set; }

        public string CPF { get; set; }

        public string CNPJ { get; set; }
    }
}
