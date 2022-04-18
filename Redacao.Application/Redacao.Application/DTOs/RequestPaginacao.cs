using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.DTOs
{
    public class RequestPaginacao
    {
        public RequestPaginacao()
        {

        }

        public Int32 NumeroPagina { get; set; } = 1;

        public Int32 TamanhoPagina { get; set; } = 10;

        public bool OrdernarDecrescente { get; set; } = true;
    }
}
