using AutoMapper;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.DataAccess.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {             
                     //TSource , TDestination
            CreateMap<Employee,GetEmployeeDto>()
                .ForMember(dest=>dest.EmpType,options=>options.MapFrom(emp=>emp.EmployeeType))
                .ForMember(dest => dest.EmpGender,options=>options.MapFrom(emp=>emp.Gender))
                .ForMember(dest=>dest.Department,options=>options.MapFrom(emp=>emp.Department !=null ? emp.Department.Name:null));//Get

            CreateMap<Employee,EmployeeDetailsDto>()
                .ForMember(dest=>dest.EmployeeType,options=>options.MapFrom(emp=>emp.EmployeeType))
                .ForMember(dest=>dest.Gender,options=>options.MapFrom(emp=>emp.Gender))
                .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(emp=>DateOnly.FromDateTime(emp.HiringDate)))
                .ForMember(dest=>dest.Department,options=>options.MapFrom(emp=>emp.Department !=null ? emp.Department.Name:null));//Get
      

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(empDto=>empDto.HiringDate.ToDateTime(TimeOnly.MinValue)));//Create

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(empDto => empDto.HiringDate.ToDateTime(TimeOnly.MinValue)));//Update

        }

    }
}
