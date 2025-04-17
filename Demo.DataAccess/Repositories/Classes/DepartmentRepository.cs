using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class DepartmentRepository(AppDbContext _appDbContext) : GenericRepoistory<Department>(_appDbContext), IDepartmentRepository
    {


    }
}
