using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.SharedModels;

namespace Demo.DataAccess.Models.DepartmentModels
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
