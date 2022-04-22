using Redacao.Domain.Entidades.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Redacao.Domain.Repositorios
{
    public interface IRepositorioGenerico<TEntity> : IDisposable where TEntity : EntidadeBase 
    {
        Task Delete(TEntity entity);
        Task Delete(List<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null);
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, Int32 numeroPagina = 1, Int32 tamanhoPagina = 10, bool orderByDesc = true);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, string[] includes = null);
        Task Create(TEntity entity);
        Task Create(List<TEntity> entity);
        Task Update(TEntity entity);
        Task Update(List<TEntity> entity);
        Task<Int32> Count();
        Task Save();
    }
}
