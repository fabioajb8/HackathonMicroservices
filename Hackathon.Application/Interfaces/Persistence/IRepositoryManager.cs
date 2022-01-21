namespace Hackathon.Application.Interfaces.Persistence.DomainRepositories
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get;}

        IUnitOfWork UnitOfWork { get;}
    }
}
