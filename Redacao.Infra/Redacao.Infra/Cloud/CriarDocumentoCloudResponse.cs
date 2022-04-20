using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Cloud
{
    public class CriarDocumentoCloudResponse
    {
        public CriarDocumentoCloudResponse()
        {

        }

        public string NomeArquivo { get; set; }

        public string NomeArquivoCloud { get; set; }
        
        public string Extensao { get; set; }

        public string Tamanho { get; set; }
    }
}
