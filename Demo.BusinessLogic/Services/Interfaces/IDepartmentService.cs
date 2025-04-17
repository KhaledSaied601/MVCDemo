using Demo.BusinessLogic.DTOs.DepartmentDtos;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        int CreateDepartment(CreateDepartmentDto createDepartmentDto);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentDetailsById(int Id);
        int? UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
        bool DeleteDepartment(int id);
    }
}