using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Data.Repositorios.Dapper
{
    public class RedacaoRepositorio : IRedacaoRepositorio
    {
        private readonly string _conexao;
        private readonly IConfiguration _configuration;
        public RedacaoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            _conexao = _configuration.GetConnectionString("RedacaoSQLServerConnection");
        }
        public async Task<IEnumerable<RedacaoRedacao>> Buscar()
        {
            using var conexao = new SqlConnection(_conexao);

            await conexao.OpenAsync();

            var redacoes = await conexao.QueryAsync<RedacaoRedacao>("SELECT * FROM dbo.Redacoes");

            await conexao.CloseAsync();

            return redacoes;
        }
    }
}
