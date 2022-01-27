using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Persistence.DomainRepositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default, bool trackChanges = false)
            => await FindAll(cancellationToken, trackChanges).ToListAsync();

        public async Task<Employee> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false)
            => await FindByCondition(e => e.Id.Equals(employeeId), cancellationToken, trackChanges).SingleOrDefaultAsync();

        public async Task InsertAsync(Employee employee, CancellationToken cancellationToken = default)
            => await Insert(employee, cancellationToken);

        public new void Remove(Employee employee)
            => base.Remove(employee);
    }
}