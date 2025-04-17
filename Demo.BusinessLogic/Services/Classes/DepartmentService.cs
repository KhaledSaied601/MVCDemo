using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.Factories;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    //Primary Constructour
    {


        //Get All Department
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _departmentRepository.GetAll().Select(d => d.ToDepartmentDto());
        }

        //Get Department By Id
        public DepartmentDetailsDto? GetDepartmentDetailsById(int Id)
        {


            var department = _departmentRepository.GetById(Id);

            //Manual Mapping
            return department is null ? null : department.ToDepartmentDetailsDto();


            //Types of Mapping :
            // 1- Manual Mapping 
            //2- Constructor Mapping 
            //3-Extension Method Mapping
            //4- Mapper

        }

        public int CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {

            var res = _departmentRepository.Add(createDepartmentDto.ToEntity());
            return res;
        }

        public int? UpdateDepartment(UpdateDepartmentDto updateDepartmentDto)
        {

            var res = _departmentRepository.Update(updateDepartmentDto.ToEntity());
            return res;
        }

        public bool DeleteDepartment(int id)
        {

            var department = _departmentRepository.GetById(id);
            if (department is null) return false;
            else
            {

                var res = _departmentRepository.Remove(department);
                return res > 0 ? true : false;
            }
        }

    }
}
