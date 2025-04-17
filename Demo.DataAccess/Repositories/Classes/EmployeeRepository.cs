using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class EmployeeRepository(AppDbContext _appDbContext):GenericRepoistory<Employee>(_appDbContext),IEmployeeRepoistory
    {

    }
}
