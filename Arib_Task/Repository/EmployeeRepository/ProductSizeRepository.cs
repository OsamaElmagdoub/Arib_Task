//using Arib_Task.ApplicationDbContext;
//using Arib_Task.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Arib_Task.Repository.ProductRepository
//{
//    public class ProductSizeRepository : IProductSizeRepository
//    {
//        private readonly AppDbContext _context;

//        public ProductSizeRepository(AppDbContext context)
//        {
//            _context = context;
//        }
//        public async Task Add(ProductSize productSize)
//        {
//            await _context.ProductSizes.AddAsync(productSize);
//            //await _context.SaveChangesAsync();
//        }

//        public async Task Delete(ProductSize productSize)
//        {
//             _context.ProductSizes.Remove(productSize);
//        }

//        public async Task<IEnumerable<ProductSize>> GetAllAsync()
//        {
//          return  await _context.ProductSizes.ToListAsync();
//        }

//        public async Task<ProductSize> GetByIdAsync(int id)
//        {
//            return await  _context.ProductSizes.FindAsync(id);
//        }

//        public async Task<IEnumerable<ProductSize>> GetByProductIdAsync(int productId)
//        {

//            return await _context.ProductSizes
//                .Where(ps=>ps.ProductId == productId)
//                .ToListAsync();
//        }

//        public async Task SaveChanges()
//        {
//            await _context.SaveChangesAsync();
//        }

//        public async Task Update(ProductSize productSize)
//        {
//             _context.ProductSizes.Update(productSize);
//        }
//    }
//}
