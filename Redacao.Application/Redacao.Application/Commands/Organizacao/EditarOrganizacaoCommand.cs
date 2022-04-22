using MediatR;
using Redacao.Application.DTOs;
using Redacao.Application.DTOs.Usuario.Identity;
using Redacao.Domain.Enums.Organizacao;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Organizacao
{
    public class EditarOrganizacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public EditarOrganizacaoCommand()
        {

        }

        public Int32 Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string CorPrimaria { get; set; }

        public string CorSecundaria { get; set; }

        public TipoOrganizacaoEnum TipoOrganizacao { get; set; }
    }
}
