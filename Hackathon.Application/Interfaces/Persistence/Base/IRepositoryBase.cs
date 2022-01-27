using System.Linq.Expressions;

namespace Hackathon.Application.Interfaces.Persistence.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(CancellationToken cancellationToken, bool trackChanges);

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, CancellationToken cancellationToken, bool trackChanges);

        Task Insert(T entity, CancellationToken cancellationToken = default);

        void Remove(T entity);
    }
}