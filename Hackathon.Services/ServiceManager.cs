using AutoMapper;
using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Service;

namespace Hackathon.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repository, IMapper mapper)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService( repository , mapper));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
