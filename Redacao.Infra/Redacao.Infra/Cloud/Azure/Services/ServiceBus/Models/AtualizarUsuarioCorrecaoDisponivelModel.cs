using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Cloud.Azure.Services.ServiceBus.Model
{
    public class AtualizarUsuarioCorrecaoDisponivelModel 
    {
        public AtualizarUsuarioCorrecaoDisponivelModel()
        {

        }

        public AtualizarUsuarioCorrecaoDisponivelModel(Int32 usuarioId, Int32 quantidade, bool adicionar)
        {
            this.UsuarioId = usuarioId;
            this.Quantidade = quantidade;
            this.Adicionar = adicionar;
        }

        public Int32 UsuarioId { get; set; }

        public Int32 Quantidade { get; set; }

        public bool Adicionar { get; set; }
    }
}
