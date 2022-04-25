using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Redacao.Infra.Email.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Infra.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly ConfiguracaoEmail _configuracao;

        public EmailService(IOptions<ConfiguracaoEmail> configuracao)
        {
            _configuracao = configuracao.Value;
        }

        public async Task EnviarEmail(RequestEmail request)
        {
            try
            {
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse(_configuracao.Email);
                email.To.Add(MailboxAddress.Parse(request.Para));
                email.Subject = request.Assunto;

                var builder = new BodyBuilder();
                if (request.Anexos != null)
                {
                    byte[] fileBytes;
                    foreach (var file in request.Anexos)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }

                builder.HtmlBody = request.Corpo;
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(_configuracao.Host, _configuracao.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuracao.Email, _configuracao.Senha);
                await smtp.SendAsync(email);
                
                smtp.Disconnect(true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
