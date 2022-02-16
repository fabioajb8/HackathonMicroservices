using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Application.Interfaces.Services;


namespace Hackathon.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repository /*, ILoggerManager logger, IMapper mapper*/)
        {
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService( repository /*, logger, mapper*/));
        }

        public IEmployeeService EmployeeService => _employeeService.Value;
    }
}
