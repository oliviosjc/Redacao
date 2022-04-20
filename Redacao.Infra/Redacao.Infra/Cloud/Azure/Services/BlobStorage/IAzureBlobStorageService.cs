using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<CriarDocumentoCloudResponse> CriarDocumento(IFormFile arquivo);
    }
}
