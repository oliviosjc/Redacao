using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redacao.Infra.Email.Models
{
    public class RequestEmail
    {
        public RequestEmail()
        {

        }

        public string Para { get; set; }

        public string Assunto { get; set; }

        public string Corpo { get; set; }

        public List<IFormFile> Anexos { get; set; }
    }
}
