using Hackathon.Application.Interfaces.Persistence;
using Hackathon.Application.Interfaces.Persistence.DomainRepositories;
using Hackathon.Persistence.DomainRepositories;

namespace Hackathon.Persistence
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(repositoryContext));
        }
        public IEmployeeRepository Employee => _employeeRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}