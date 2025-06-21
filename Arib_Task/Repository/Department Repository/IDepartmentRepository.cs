using Arib_Task.Models;

namespace Arib_Task.Repository.Department_Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllWithEmployees();
        Task<int> Count();

    }
}
