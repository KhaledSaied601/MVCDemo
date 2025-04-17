using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.DataAccess.Models.DepartmentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factories
{
    public static class DepartmentFactory
    {
        //Mapping Extension Methods
        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            DepartmentDto departmentDto = new DepartmentDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateOfCreation = department.CreatedOn,

            };
            return departmentDto;
        }   
        
        public static DepartmentDetailsDto ToDepartmentDetailsDto(this Department department)
        {
            DepartmentDetailsDto departmentDetailsDto = new DepartmentDetailsDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code,
                DateOfCreation = department.CreatedOn,
                IsDeleted = department.IsDeleted,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn


            };
            return departmentDetailsDto;
        }


        public static Department ToEntity( this CreateDepartmentDto createDepartmentDto)
        {
            return new Department()
            {
                Code = createDepartmentDto.Code,
                Name = createDepartmentDto.Name,
                Description = createDepartmentDto.Description,
                CreatedOn = createDepartmentDto.DateOfCreation
            };
        }  
        public static Department ToEntity( this UpdateDepartmentDto updateDepartmentDto)
        {
            return new Department()
            {
                Code = updateDepartmentDto.Code,
                Name = updateDepartmentDto.Name,
                Description = updateDepartmentDto.Description,
                CreatedOn = updateDepartmentDto.DateOfCreation
            };
        }
    }
}
