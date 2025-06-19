

using Arib_Task.Models;

namespace Arib_Task.Repository.ProductRepository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesWithDepartment();
        //Task<IEnumerable<Employee>> GetProductsByCategoryId(int categoryId);
        //Task<IEnumerable<Employee>> Search(string keyword);
        //void DeleteProduct(int productId);
        //Task<bool> UpdateProduct(int id, EditProductViewModel viewModel);

        Task<int> Count();
        //Task<Product?> GetProductById(int id);

    }
}
