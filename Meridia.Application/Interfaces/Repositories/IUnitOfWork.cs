using System;
using Meridia.Domain.Entities.Common;

namespace Meridia.Application.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
        Task<int> SaveChangesAsync();
        Task RollBackChangesAsync();
        IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity;
    }
}

