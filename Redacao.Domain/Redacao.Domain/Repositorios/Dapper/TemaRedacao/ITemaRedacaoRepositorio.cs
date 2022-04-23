using Redacao.Domain.Entidades.Redacao;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Repositorios.Dapper.TemaRedacao
{
    public interface ITemaRedacaoRepositorio
    {
        Task Curtir(Int32 usuarioId, Int32 temaRedacaoId, bool curtida);
    }
}
