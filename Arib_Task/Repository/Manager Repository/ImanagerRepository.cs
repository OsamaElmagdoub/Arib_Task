using Arib_Task.Models;

namespace Arib_Task.Repository.Manager_Repository
{
    public interface ImanagerRepository : IGenericRepository<Manager>
    {
        //Task<Department> GetDepatartmentWithEmployees(int id);
        //Task<IEnumerable<Department>> GetAllWithEmployees();
        Task<int> Count();
        //Task<bool> UpdateCategory(int id, EditCategoryViewModel viewModel);
        //Task<bool> DeleteCategory(int id);
        //Task<bool> SoftDeleteCategory(int id);
        //Task GetAllWithProductsAsync();
    }
}
