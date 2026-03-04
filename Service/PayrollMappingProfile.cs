using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using System;

namespace Service.MappingProfiles
{
    public class PayrollMappingProfile : Profile
    {
        public PayrollMappingProfile()
        {
            // Salary mappings
            CreateMap<Salary, SalaryDto>().ReverseMap();
            CreateMap<SalaryForCreationDto, Salary>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
            CreateMap<SalaryForUpdateDto, Salary>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());

            // Payslip mappings
            CreateMap<Payslip, PayslipDto>().ReverseMap();
            CreateMap<PayslipForCreationDto, Payslip>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore());
            CreateMap<PayslipDto, Payslip>()
                .ForMember(dest => dest.Employee, opt => opt.Ignore());

            // LeaveRecord mappings
            CreateMap<LeaveRecord, LeaveRecordDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<LeaveRecordForCreationDto, LeaveRecord>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Employee, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (src.Type)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => LeaveStatus.Pending))
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days > 0 ? src.Days : (src.EndDate - src.StartDate).Days + 1));

            CreateMap<LeaveRecordForUpdateDto, LeaveRecord>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (src.Type)))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (src.Status)))
                .ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.Days > 0 ? src.Days : (src.EndDate - src.StartDate).Days + 1))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }

        private static LeaveType ParseLeaveType(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return LeaveType.Paid;

            return Enum.TryParse<LeaveType>(value, true, out var parsed) ? parsed : LeaveType.Other;
        }

        private static LeaveStatus ParseLeaveStatus(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return LeaveStatus.Pending;

            return Enum.TryParse<LeaveStatus>(value, true, out var parsed) ? parsed : LeaveStatus.Pending;
        }
    }
}