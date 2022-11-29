using AutoMapper;
using Nptk.Learning.Entities;
using Nptk.Learning.Shared.DataTransferObjects;

namespace Nptk.Learning.Main
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
            .ForCtorParam("FullAddress",
            opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));

            CreateMap<Employee, EmployeeDto>();

        }
    }
}