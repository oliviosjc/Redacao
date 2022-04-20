using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Redacao.Infra.Cloud.Azure.Services.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Redacao.Infra.Cloud.Azure.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<CriarDocumentoCloudResponse> CriarDocumento(IFormFile arquivo)
        {
            CriarDocumentoCloudResponse response = new CriarDocumentoCloudResponse();

            string blobConnectionString = _configuration.GetValue<string>("Azure:BlobConnectionString");

            var nomeArquivo = Path.GetFileName(arquivo.FileName);
            var extensao = Path.GetExtension(arquivo.FileName);
            var nomeArquivoCloud = Guid.NewGuid().ToString();

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue<string>("Azure:ContainerTema"));
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(nomeArquivoCloud + extensao);

            await using (var data = arquivo.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }

            response.NomeArquivo = nomeArquivo;
            response.NomeArquivoCloud = nomeArquivoCloud;
            response.Extensao = extensao;
            response.Tamanho = "1";

            return response;
        }
    }
}
