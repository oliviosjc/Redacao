using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Email.Models
{
    public class ConfiguracaoEmail
    {
        public ConfiguracaoEmail()
        {

        }

        public string Email { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public string Host { get; set; }

        public Int32 Port { get; set; }
    }
}
