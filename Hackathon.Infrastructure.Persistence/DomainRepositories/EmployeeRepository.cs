using Hackathon.Application.Common.Models;
using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Application.Models.Employee;
using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Persistence.DomainRepositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<Employee>> GetAllAsync(EmployeeParameters employeeParameters, CancellationToken cancellationToken = default, bool trackChanges = false)
        {
            var employees = await FindAll(cancellationToken, trackChanges)
                .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                .Take(employeeParameters.PageSize)
                .ToListAsync(cancellationToken);
            
            var count = await FindAll(cancellationToken, trackChanges).CountAsync();
            
            return PagedList<Employee>.ToPageList(employees, count, employeeParameters.PageNumber, employeeParameters.PageSize);
        }

        public async Task<Employee> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false)
            => await FindByCondition(e => e.Id.Equals(employeeId), cancellationToken, trackChanges).SingleOrDefaultAsync();

        public async Task InsertAsync(Employee employee, CancellationToken cancellationToken = default)
            => await Insert(employee, cancellationToken);

        public new void Remove(Employee employee)
            => base.Remove(employee);
    }
}