using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Configuracao
{
    public class ConfiguracaoFila
    {
        public ConfiguracaoFila()
        {

        }

        public string Conexao { get; set; }

        public string NomeFilaUsuarioCorrecaoDisponivel { get; set; }

        public Int32 QuantidadeMinutosTentativa { get; set; }

        public Int32 QuantidadeTentativas { get; set; }
    }
}
