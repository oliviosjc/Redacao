using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Redacao.Application.DTOs
{
    public  class ResponseViewModel<T> where T : class
    {
        public ResponseViewModel()
        {

        }

        public ResponseViewModel(HttpStatusCode httpStatusCode, T data, string message, ResponsePaginacao paginacaoModel)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Data = data;
            this.Message = message;
            this.Paginacao = paginacaoModel;
        }

        public string Message { get; set; }

        public T Data { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ResponsePaginacao Paginacao { get; set; }
    }
}
