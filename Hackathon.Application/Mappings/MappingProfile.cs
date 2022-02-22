using AutoMapper;
using Hackathon.Application.DataTransferObjects;
using Hackathon.Domain.Entities;

namespace Hackathon.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(e => e.Address, y => y.MapFrom(e => e.Address.Line1));
            CreateMap<EmployeeForCreationDto, Employee>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Address, y => y.Ignore());
            CreateMap<EmployeeForUpdateDto, Employee>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Address, y => y.Ignore());

        }
    }
}