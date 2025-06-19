using Arib_Task.ApplicationDbContext;
using Arib_Task.Models;
using Arib_Task.Repository.Department_Repository;
using Arib_Task.Repository.Manager_Repository;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Repository.Category_Repository
{

    public class ManagerRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public ManagerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Departments.CountAsync();
        }

        ////public async Task<bool> DeleteCategory(int id)
        ////{
        ////    var categorey = await _context.Categories
        ////        .Include(c => c.Products)
        ////        .FirstOrDefaultAsync(c => c.Id == id);


        ////    if (categorey == null)
        ////    {
        ////        return false;
        ////    }
        ////    // امسح المنتجات المرتبطة أولاً

        ////    _context.Products.RemoveRange(categorey.Products);

        ////    // ثم احذف الكاتيجوري
        ////    _context.Categories.Remove(categorey);

        ////    await _context.SaveChangesAsync();

        ////    return true;
        ////}

        public async Task<IEnumerable<Department>> GetAllWithEmployees()
        {
            return await _context.Departments
                .Include(c => c.Employees)
                .ToListAsync();
        }

        //public Task GetAllWithProductsAsync()
        //{
        //    throw new NotImplementedException();
        //}




        //public async Task<Category> GetCategoryWithProducts(int id)
        //{
        //    var category = await _context.Categories
        //        .Include(c => c.Products)
        //        .FirstOrDefaultAsync(c => c.Id == id);
        //    return category;
        //}

        //public async Task<bool> SoftDeleteCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //        return false;

        //    category.IsDeleted = true;
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> UpdateCategory(int id, EditCategoryViewModel viewModel)
        //{
        //    var categorey = await _context.Categories.FindAsync(id);
        //    if (categorey == null)
        //    {
        //        return false;
        //    }
        //    categorey.Name = viewModel.Name;
        //    _context.Categories.Update(categorey);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}

