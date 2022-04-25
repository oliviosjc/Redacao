using Redacao.Infra.Email.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Infra.Email.Services
{
    public interface IEmailService
    {
        Task EnviarEmail(RequestEmail request);
    }
}
