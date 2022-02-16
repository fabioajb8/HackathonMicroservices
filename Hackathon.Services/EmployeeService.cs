using Hackathon.Application.DataTransferObjects;
using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Exceptions.NotFoundException;
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

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken cancellationToken = default, bool trackChanges = false)
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

        public async Task<EmployeeDto> GetByIdAsync(Guid employeeId, CancellationToken cancellationToken = default, bool trackChanges = false)
        {
            var employeeFromDb = await _repositoryManager.Employee.GetByIdAsync(employeeId);
            if(employeeFromDb is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }

            return new EmployeeDto
            {
                Id = employeeFromDb.Id,
                Name = employeeFromDb.Name,
                Address = employeeFromDb.Address?.Line1,
                Email = employeeFromDb.Email,
                NIF = employeeFromDb.NIF,
                OldId = employeeFromDb.OldId
            };
        }

        public Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto employeeForUpdate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
