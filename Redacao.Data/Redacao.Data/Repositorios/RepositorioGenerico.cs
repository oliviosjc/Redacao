using Microsoft.EntityFrameworkCore;
using Redacao.Data.Context;
using Redacao.Domain.Entidades.Base;
using Redacao.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Redacao.Data.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : EntidadeBase
    {
        private readonly RedacaoSQLContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public RepositorioGenerico(RedacaoSQLContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Create(List<TEntity> entity)
        {
            await _dbSet.AddRangeAsync(entity);
        }

        public Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);

            return Task.FromResult(true);
        }

        public Task Delete(List<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            var query = _dbSet.AsNoTracking().AsQueryable();

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null)
        {
            var query = _dbSet.AsNoTracking().AsQueryable();

            if (!(predicate is null))
                query = query.Where(predicate);

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate = null, string[] includes = null, int numeroPagina = 1, int tamanhoPagina = 10, bool orderByDesc = true)
        {
            var query = _dbSet.AsNoTracking().AsQueryable();

            if (!(predicate is null))
                query = query.Where(predicate);

            if (!(includes is null))
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            var skip = (numeroPagina - 1) * tamanhoPagina;

            query = query.Skip(skip).Take(tamanhoPagina);

            if (orderByDesc)
                query = query.OrderByDescending(or => or.Id);
            else
                query = query.OrderBy(or => or.Id);

            return await query.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            _context.Update(entity);
            return Task.FromResult(true);
        }

        public Task Update(List<TEntity> entity)
        {
            _context.UpdateRange(entity);
            return Task.FromResult(true);
        }
    }
}
