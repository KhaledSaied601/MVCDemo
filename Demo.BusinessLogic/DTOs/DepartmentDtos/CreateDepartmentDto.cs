using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DTOs.DepartmentDtos
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Name Is Requird")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Code Is Requird")]

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DateOfCreation { get; set; }
    }
}
