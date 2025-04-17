using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using System.Reflection;

namespace Demo.DataAccess.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }


        // Because of Dependency Injection
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer()
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }



    }
}
