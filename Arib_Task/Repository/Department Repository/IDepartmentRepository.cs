using Arib_Task.Models;

namespace Arib_Task.Repository.Department_Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        //Task<Department> GetDepatartmentWithEmployees(int id);
        Task<IEnumerable<Department>> GetAllWithEmployees();
        Task<int> Count();
        //Task<bool> UpdateCategory(int id, EditCategoryViewModel viewModel);
        //Task<bool> DeleteCategory(int id);
        //Task<bool> SoftDeleteCategory(int id);
        //Task GetAllWithProductsAsync();
    }
}
