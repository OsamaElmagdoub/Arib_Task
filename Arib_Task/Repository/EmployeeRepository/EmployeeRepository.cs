using Arib_Task.ApplicationDbContext;
using Arib_Task.Models;
using Arib_Task.Repository.ProductRepository;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Repository.Employee_Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context) : base(context)

        {
            _context = context;
        }

        //public async Task<IEnumerable<Product>> GetProductsCategory(int categoryId)
        //{
        //    var products = await _context.Products
        //        .Where(p => p.CategoryId == categoryId)
        //        .Include(p => p.Category).ToListAsync();

        //    return products;
        //}

        //public async Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId)
        //{
        //    var products = await _context.Products
        //        .Where(p => p.CategoryId == categoryId)
        //        .Include(p => p.Category)
        //        .Include(p => p.Images).Include(p => p.Sizes).ToListAsync();

        //    return products;
        //}

        //public async Task<IEnumerable<Product>> Search(string keyword)
        //{
        //    var searchedItem = await _context.Products
        //        .Where(p => p.Name.Contains(keyword) || p.Description.Contains(keyword))
        //        .ToListAsync();

        //    return searchedItem;
        //}

        public async Task<IEnumerable<Employee>> GetAllEmployeesWithDepartment()
        {
            var employees = await _context.Employees
                //.Include(p => p.Images)
                .Include(p => p.Department)
                /*.Include(p => p.Sizes)*/.ToListAsync();
            return employees;
        }

        //public void DeleteProduct(int productId)
        //{
        //    var product = _context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == productId);

        //    if (product != null)
        //    {
        //        _context.Remove(product);
        //        _context.SaveChanges();
        //    }
        //}

        public async Task<int> Count()

        {
            return await _context.Employees.CountAsync();
        }

        public async Task<Employee?> GetEmployeeWithDetailsById(int id)
        {
            return await _context.Employees
                .Include(e => e.Manager)
                .Include(e => e.Department)
                .Include(e => e.Tasks)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        //public async Task<Product?> GetProductById(int id)
        //{
        //    return await _context.Products
        //        .Include(p => p.Category)
        //        .Include(p => p.Images)
        //        .Include(p => p.Sizes)
        //        // إضافة جلب المقاسات مع المنتج
        //        .FirstOrDefaultAsync(p => p.Id == id);
        //}

        //public async Task<bool> UpdateProduct(int id, EditProductViewModel viewModel)
        //{
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return false;
        //    }

        //    product.VideoUrl = viewModel.VideoUrl;
        //    product.Description = viewModel.Description;
        //    product.Category = product.Category;
        //    product.Price = viewModel.Price;
        //    product.VideoUrl = viewModel.VideoUrl;

        //    _context.Products.Update(product);
        //    await _context.SaveChangesAsync();
        //    return true;

        //}
    }
}
