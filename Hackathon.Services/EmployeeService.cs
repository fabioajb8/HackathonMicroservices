using Hackathon.Application.DataTransferObjects;
using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        public EmployeeService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager; 
        }

        public Task<EmployeeDto> CreateAsync(EmployeeForCreationDto employeeForCreation, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid employeeId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false)
        {
            var employees = await _repositoryManager.Employee.GetAllAsync(cancellationToken, trackChanges);
            List<EmployeeDto> employeeDtos = new List<EmployeeDto>();

            foreach (Employee employee in employees)
            {
                employeeDtos.Add(new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = employee.Address?.Line1,
                    Email = employee.Email,
                    NIF = employee.NIF,
                    OldId = employee.OldId
                });  
            }

            return employeeDtos;
        }

        public Task<EmployeeDto> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto employeeForUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
