using Hackathon.Application.Common.Models;
using Hackathon.Application.DataTransferObjects;
using Hackathon.Application.Models.Employee;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<EmployeeDto>, MetaData metaData)> GetAllAsync(EmployeeParameters employeeParameters, CancellationToken cancellationToken = default, bool trackChanges = false);

        Task<EmployeeDto> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false);

        Task<EmployeeDto> CreateAsync(EmployeeForCreationDto employeeForCreation, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto employeeForUpdate, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid employeeId, CancellationToken cancellationToken = default);
    }
}
