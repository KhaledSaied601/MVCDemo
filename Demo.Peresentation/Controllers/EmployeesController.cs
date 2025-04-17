using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.Peresentation.ViewModels.DepartmentsViewModels;
using Demo.Peresentation.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Peresentation.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index()
        {
            
           var employee = _employeeService.GetAllEmployee();
            return View(employee);
        }


        #region Create Employee

        [HttpGet]
        public IActionResult Create()
        {


            return View();


        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    CreateEmployeeDto createEmployeeDto = new CreateEmployeeDto()
                    {
                        Name = employeeViewModel.Name,
                        Address = employeeViewModel.Address,
                        DepartmentId = employeeViewModel.DepartmentId,
                        HiringDate = employeeViewModel.HiringDate,
                        Age = employeeViewModel.Age,
                        Email = employeeViewModel.Email,
                        EmployeeType = employeeViewModel.EmployeeType,
                        Gender = employeeViewModel.Gender,
                        IsActive = employeeViewModel.IsActive,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        Salary = employeeViewModel.Salary
                    };

                    int? result = _employeeService.CreateEmployee(createEmployeeDto);

                    if (result > 0) return RedirectToAction("Index");

                    //if (result > 0) return View(nameof(Index));    // It will make Error Because of Return View different than RedirectToAction !! and URL will Not Change of Action   


                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee Can't be Created");
                        return View(employeeViewModel);
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }


            }
            return View(employeeViewModel);

        }
        #endregion


        //Get Details
        public IActionResult Details(int? id)
        {

            if (id.HasValue)
            {

                var employee = _employeeService.GetEmployeeById(id.Value);

                if (employee == null) return NotFound();
                return View(employee);
            }
            else return BadRequest();




        }


        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);

            //Map From EmployeeDetailsDto to UpdateEmployeeDto
            var employeeViewModel = new EmployeeViewModel()
            {
                
                Name = employee.Name,
                HiringDate = employee.HiringDate,
                Address = employee.Address,
                Age = employee.Age,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender)
                ,DepartmentId=employee.DepartmentId

            };




            return View(employeeViewModel);


        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel employeeViewModel)
        {

            if(!id.HasValue ) return BadRequest();




            if (!ModelState.IsValid) return View(employeeViewModel);

            try
            {
         

                var employeeDto = new UpdateEmployeeDto()
                {
                    Id = id.Value,
                    Name = employeeViewModel.Name,
                    HiringDate = employeeViewModel.HiringDate,
                    Address = employeeViewModel.Address,
                    Age = employeeViewModel.Age,
                    IsActive = employeeViewModel.IsActive,
                    Email = employeeViewModel.Email,
                    PhoneNumber = employeeViewModel.PhoneNumber,
                    Salary = employeeViewModel.Salary,
                    EmployeeType =employeeViewModel.EmployeeType,
                    Gender = employeeViewModel.Gender
           ,
                    DepartmentId = employeeViewModel.DepartmentId

                };

                var res = _employeeService.UpdateEmployee(employeeDto);

                if (res > 0) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can't Be Updated");
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
            return View(employeeViewModel);
        }
        #endregion


        #region DeleteEmployee
        [HttpPost]
        public IActionResult Delete(int id) 
        { 
        if(id==0) return BadRequest();

            try
            {
                var isDeleted = _employeeService.DeleteEmployee(id);
                if (isDeleted) return RedirectToAction("Index");
                else
                {
                    ModelState.AddModelError(string.Empty, "Employee Can't be Deleted");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
        
            catch(Exception ex)
            
                {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }
         return View("Error");
        
        }
        #endregion
    }
}
