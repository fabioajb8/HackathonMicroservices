using Hackathon.Application.Interfaces.Persistence;

namespace Hackathon.Persistence
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;
        public UnitOfWork(RepositoryContext repositoryContext)
            => _repositoryContext = repositoryContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => _repositoryContext.SaveChangesAsync(cancellationToken);
    }
}