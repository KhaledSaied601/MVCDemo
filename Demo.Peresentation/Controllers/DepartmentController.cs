using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.Peresentation.ViewModels.DepartmentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Peresentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment
        ) : Controller
    {
        public IActionResult Index()
        {
           var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }


        #region Create Department
        [HttpGet]
        public IActionResult Create(int id)
        {

            return View();


        }

        [HttpPost]
        public IActionResult Create(DepartmentEditViewModel departmentEditViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createDepartmentDto = new CreateDepartmentDto()
                    {
                        Code = departmentEditViewModel.Code,
                        Name = departmentEditViewModel.Name,
                        DateOfCreation = departmentEditViewModel.DateOfCreation,
                        Description = departmentEditViewModel.Description,
                    };

                    int? result = _departmentService.CreateDepartment(createDepartmentDto);

                    if (result > 0) return RedirectToAction("Index");

                    //if (result > 0) return View(nameof(Index));    // It will make Error Because of Return View different than RedirectToAction !! and URL will Not Change of Action   


                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't be Created");
                        return View(departmentEditViewModel);
                    }
                }
                catch (Exception ex)
                {
                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }
                }


            }
            return View(departmentEditViewModel);


        }
        #endregion



        //Get Details
        public IActionResult Details(int? id) 
        {
            if (id.HasValue)
            {

                var department =  _departmentService.GetDepartmentDetailsById(id.Value);

                if (department == null) return NotFound();  
                return View(department);
            }
            else return BadRequest();


        
        
        }

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentDetailsById(id.Value);

            if (department == null) return NotFound();
            else
            {

                var departmentViewModel = new ViewModels.DepartmentsViewModels.DepartmentEditViewModel()
                {
                    Code = department.Code,
                    Name = department.Name,
                    DateOfCreation = department.DateOfCreation,
                    Description = department.Description
                };

                return View(departmentViewModel);
            }


        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id, ViewModels.DepartmentsViewModels.DepartmentEditViewModel departmentEditViewModel)
        {
            if (!ModelState.IsValid) return View(departmentEditViewModel);

            try
            {
                //Map from DepartmentViewModel To UpdateViewModel
                var updatedDept = new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = departmentEditViewModel.Code,
                    Name = departmentEditViewModel.Name,
                    DateOfCreation = departmentEditViewModel.DateOfCreation,
                    Description = departmentEditViewModel.Description
                };

               var res = _departmentService.UpdateDepartment(updatedDept);
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
            return View(departmentEditViewModel);
        }
        #endregion

        //Delete Department
        #region Delete

        //[HttpGet]

        //public IActionResult Delete(int? id)
        //{

        //    if (!id.HasValue) return BadRequest();
        //    var department = _departmentService.GetDepartmentDetailsById(id.Value);

        //    if (department == null) return NotFound();
        //    return View(department);


        //}


        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();

            try
            {
                var IsDeleted = _departmentService.DeleteDepartment(id);

                if (IsDeleted) return RedirectToAction(nameof(Index));

                ModelState.AddModelError(string.Empty, "Department Can't be deleted");

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

            return RedirectToAction(nameof(Delete), new { id });



        } 
        #endregion

    }
}
