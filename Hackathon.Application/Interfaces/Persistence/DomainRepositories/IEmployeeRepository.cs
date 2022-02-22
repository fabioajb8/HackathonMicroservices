using Hackathon.Application.Common.Models;
using Hackathon.Application.Models.Employee;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Interfaces.Persistence.DomainRepositories
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetAllAsync(EmployeeParameters employeeParameters, CancellationToken cancellationToken = default, bool trackChanges = false);

        Task<Employee> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false);

        Task InsertAsync(Employee employee, CancellationToken cancellationToken = default);

        void Remove(Employee employee);
    }
}
