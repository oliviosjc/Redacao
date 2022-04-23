using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Redacao.Domain.Entidades.Redacao;
using Redacao.Domain.Repositorios.Dapper.TemaRedacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Data.Repositorios.Dapper.TemaRedacao
{
    public class TemaRedacaoRepositorio : ITemaRedacaoRepositorio
    {
        private readonly string _conexao;
        private readonly IConfiguration _configuration;

        public TemaRedacaoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            _conexao = _configuration.GetConnectionString("RedacaoSQLServerConnection");
        }

        public async Task Curtir(int usuarioId, int temaRedacaoId, bool curtida)
        {
            using var conexao = new SqlConnection(_conexao);

            await conexao.OpenAsync();

            var temaRedacaoUsuarioCurtida = await conexao.QueryFirstOrDefaultAsync<TemaRedacaoUsuarioCurtida>("SELECT * FROM dbo.TemaRedacaoUsuarioCurtidas" +
                                                                               "WHERE UsuarioId = @usuarioId AND TemaRedacaoId = @temaRedacaoId",
                                                                               new { UsuarioId = usuarioId, TemaRedacaoId = temaRedacaoId });

            string query;

            if(temaRedacaoUsuarioCurtida is null)
            {
                query = "INSERT INTO dbo.TemaRedacaoUsuarioCurtidas(UsuarioId, TemaRedacaoId, Curtida) VALUES (@usuarioId, @temaRedacaoId, @curtida)";
                await conexao.ExecuteAsync(query, new { usuarioId = usuarioId, temaRedacaoId = temaRedacaoId, curtida = curtida });
            }
            else
            {
                if(temaRedacaoUsuarioCurtida.Curtida == curtida)
                {
                    query = "DELETE FROM dbo.TemaRedacaoUsuarioCurtidas WHERE UsuarioId = @usuarioId AND TemaRedacaoId = @temaRedacaoId";
                    await conexao.ExecuteAsync(query, new { usuarioId = usuarioId, temaRedacaoId = temaRedacaoId});
                }
                else
                {
                    query = "UPDATE dbo.TemaRedacaoUsuarioCurtidas SET Curtida = @curtida WHERE UsuarioId = @usuarioId AND TemaRedacaoId = @temaRedacaoId";
                    await conexao.ExecuteAsync(query, new { usuarioId = usuarioId, temaRedacaoId = temaRedacaoId, curtida = curtida});
                }
            }

            await conexao.CloseAsync();
        }
    }
}
