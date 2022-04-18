using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Application.DTOs
{
    public class ResponsePaginacao
    {
        public ResponsePaginacao()
        {

        }

        public Int32 NumeroPagina { get; set; }

        public Int32 TamanhoPagina { get; set; }

        public Int32 TotalPaginas { get; set; }

        public Int32 TotalRegistros { get; set; }
    }
}
