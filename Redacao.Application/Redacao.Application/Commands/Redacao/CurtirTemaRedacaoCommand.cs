using MediatR;
using Redacao.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.Commands.Redacao
{
    public class CurtirTemaRedacaoCommand : IRequest<ResponseViewModel<string>>
    {
        public CurtirTemaRedacaoCommand()
        {

        }

        public CurtirTemaRedacaoCommand(Int32 temaId, bool curtir)
        {
            this.TemaId = temaId;
            this.Curtir = curtir;
        }

        public Int32 TemaId { get; set; }

        public bool Curtir { get; set; }
    }
}
