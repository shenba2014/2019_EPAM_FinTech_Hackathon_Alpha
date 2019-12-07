using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.Entity;

namespace FinTechHackathonAlpha.WebApi.Repository
{
	public interface IGenericRepository<TEntity>
		where TEntity : class, IEntity
	{
	IQueryable<TEntity> GetAll();

	Task<TEntity> GetByIdAsync(int id);

	Task CreateAsync(TEntity entity);

	Task UpdateAsync(int id, TEntity entity);

	Task DeleteAsync(int id);
	}
}
