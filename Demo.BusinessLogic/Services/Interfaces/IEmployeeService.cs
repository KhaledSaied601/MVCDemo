using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        int CreateEmployee(CreateEmployeeDto createEmployeeDto);
        IEnumerable<GetEmployeeDto> GetAllEmployee();

        EmployeeDetailsDto? GetEmployeeById(int Id);


        int? UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        bool DeleteEmployee(int id);
    }
}
