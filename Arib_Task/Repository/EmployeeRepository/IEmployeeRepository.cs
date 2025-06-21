

using Arib_Task.Models;

namespace Arib_Task.Repository.ProductRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesWithDepartment();
        
        Task<Employee?> GetEmployeeWithDetailsById(int id);
        Task<int> Count();

        Task<List<Employee>> GetAllWithDepartmentAndManagerAsync();


    }
}
