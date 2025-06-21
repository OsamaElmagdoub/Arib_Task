using Arib_Task.ApplicationDbContext;
using Arib_Task.Models;
using Arib_Task.Repository.Department_Repository;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Repository.Category_Repository
{

    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> Count()
        {
            return await _context.Departments.CountAsync();
        }


        public async Task<IEnumerable<Department>> GetAllWithEmployees()
        {
            return await _context.Departments
                .Include(c => c.Employees)
                .ToListAsync();
        }

        



        
    }
}

