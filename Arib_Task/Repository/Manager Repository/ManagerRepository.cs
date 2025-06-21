using Arib_Task.ApplicationDbContext;
using Arib_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Repository.Manager_Repository
{

    public class ManagerRepository : GenericRepository<Manager>, ImanagerRepository
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


        public async Task<IEnumerable<Department>> GetAllWithEmployees()
        {
            return await _context.Departments
                .Include(c => c.Employees)
                .ToListAsync();
        }

        public async Task<Manager?> GetByName(string name)
        {
            return await _context.Managers.FirstOrDefaultAsync(m => m.Name == name);
        }


      


    }
}

