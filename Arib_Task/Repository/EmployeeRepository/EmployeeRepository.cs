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


        public async Task<IEnumerable<Employee>> GetAllEmployeesWithDepartment()
        {
            var employees = await _context.Employees
                
                .Include(p => p.Department)
                .ToListAsync();
            return employees;
        }

    

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


        public async Task<List<Employee>> GetAllWithDepartmentAndManagerAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .ToListAsync();
        }
        
    }
}
