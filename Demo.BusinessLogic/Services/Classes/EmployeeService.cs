using AutoMapper;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepoistory _employeeRepository,IMapper _mapper) : IEmployeeService
    {
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var mappedEmploye = _mapper.Map<Employee>(createEmployeeDto);
            return _employeeRepository.Add(mappedEmploye);
        }

     

        public IEnumerable<GetEmployeeDto> GetAllEmployee()
        {
            var employees = _employeeRepository.GetAll();

            

            return _mapper.Map<IEnumerable<GetEmployeeDto>>(employees);


             
        }

        public EmployeeDetailsDto? GetEmployeeById(int Id)
        {
            var employee = _employeeRepository.GetById(Id);     
            if (employee == null) return null;
            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public int? UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var mappedEmploye = _mapper.Map<Employee>(updateEmployeeDto);
            return _employeeRepository.Add(mappedEmploye);
        }
        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return false;
            else
            {//SoftDelete
                employee.IsDeleted = true;
                var res = _employeeRepository.Update(employee);
                return res>0?true:false;
            }

        }
    }
}
