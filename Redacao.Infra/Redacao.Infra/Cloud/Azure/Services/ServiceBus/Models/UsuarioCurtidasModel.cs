using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Models
{
    public class UsuarioCurtidasModel
    {
        public UsuarioCurtidasModel()
        {

        }

        public Int32 UsuarioId { get; set; }

        public Int32 TemaRedacaoId { get; set; }

        public bool Curtida { get; set; }
    }
}
