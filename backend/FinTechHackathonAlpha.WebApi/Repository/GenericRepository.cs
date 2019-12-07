using FinTechHackathonAlpha.WebApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinTechHackathonAlpha.WebApi.Repository
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity>
		where TEntity : class, IEntity
	{
		private readonly FinPassDbContext _dbContext;

		public GenericRepository(FinPassDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task CreateAsync(TEntity entity)
		{
			await _dbContext.Set<TEntity>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await GetByIdAsync(id);
			_dbContext.Set<TEntity>().Remove(entity);
			await _dbContext.SaveChangesAsync();
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbContext.Set<TEntity>().AsNoTracking();
		}

		public async Task<TEntity> GetByIdAsync(int id)
		{
			return await _dbContext.Set<TEntity>()
				.AsNoTracking()
				.FirstOrDefaultAsync(e => e.Id == id);
		}

		public async Task UpdateAsync(int id, TEntity entity)
		{
			_dbContext.Set<TEntity>().Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
