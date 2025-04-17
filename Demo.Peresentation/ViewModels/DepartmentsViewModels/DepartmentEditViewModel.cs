using System.ComponentModel.DataAnnotations;

namespace Demo.Peresentation.ViewModels.DepartmentsViewModels
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage = "Name Is Requird")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Code Is Requird")]

        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? DateOfCreation { get; set; }
    }
}
