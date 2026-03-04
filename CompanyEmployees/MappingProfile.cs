using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace CompanyEmployees
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                 .ForMember("FullAddress",
             opt => opt.MapFrom(x =>
            x.Address + ", " + x.Country));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee> ().ReverseMap();
            CreateMap<CompanyForUpdateDto, Company>();
            CreateMap<UserForRegistrationDto, User>();


            // Payslip mappings
            CreateMap<Payslip, PayslipDto>();
            CreateMap<PayslipForCreationDto, Payslip>();

            // Salary mappings
            CreateMap<Salary, SalaryDto>();
            CreateMap<SalaryForCreationDto, Salary>();
            CreateMap<SalaryForUpdateDto, Salary>().ReverseMap();

            // Leave mappings
            CreateMap<LeaveRecord, LeaveRecordDto>()
                .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<LeaveRecordForCreationDto, LeaveRecord>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (LeaveType)src.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (LeaveStatus)src.Status));

            CreateMap<LeaveRecordForUpdateDto, LeaveRecord>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (LeaveType)src.Type))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (LeaveStatus)src.Status))
                .ReverseMap();

        }

    }
}
