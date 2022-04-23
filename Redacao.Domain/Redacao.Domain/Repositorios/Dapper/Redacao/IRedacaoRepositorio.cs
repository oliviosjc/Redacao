using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Repositorios.Dapper
{
    public interface IRedacaoRepositorio
    {
        Task<IEnumerable<RedacaoRedacao>> Buscar();
    }
}
