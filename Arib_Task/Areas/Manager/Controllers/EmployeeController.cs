using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Arib_Task.Areas.Manager.ViewModels.EmployeeViewModel;
using Arib_Task.Repository.ProductRepository;
using Arib_Task.Repository.Department_Repository;
using Arib_Task.Repository.Manager_Repository;
using Arib_Task.Models;
using Microsoft.AspNetCore.Hosting;
using Arib_Task.Areas.Manager.ViewModels.EmployeeViewModels;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Areas.Manager.Controllers
{
    [Area("Manager")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ImanagerRepository _managerRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository , ImanagerRepository managerRepository,IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _managerRepository = managerRepository;
           _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _employeeRepository.GetAllEmployeesWithDepartment();
            
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            var departments = await _departmentRepository.GetAll();

            var model = new AddEmployeeViewModel
            {
                Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(AddEmployeeViewModel model)
        {
            // التحقق من صحة البيانات
            if (!ModelState.IsValid)
            {
                var departments = await _departmentRepository.GetAll();
                model.Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                });

                return View(model);
            }

            // التحقق من وجود المدير بالاسم
            var manager = await _managerRepository.GetByName(model.ManagerName?.Trim());
            if (manager == null)
            {
                ModelState.AddModelError("ManagerName", "❌ المدير غير موجود بالاسم المدخل");

                var departments = await _departmentRepository.GetAll();
                model.Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                });

                return View(model);
            }

            // رفع الصورة إن وجدت
            string? imageUrl = null;
            if (model.ImageFile is { Length: > 0 })
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/employees");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = Guid.NewGuid() + Path.GetExtension(model.ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await model.ImageFile.CopyToAsync(stream);

                imageUrl = "/images/employees/" + uniqueFileName;
            }

            // تحويل الـ ViewModel إلى Model باستخدام AutoMapper
            var employee = _mapper.Map<Employee>(model);
            employee.ManagerId = manager.Id;
            employee.ImageUrl = imageUrl;

            await _employeeRepository.Add(employee);
            await _employeeRepository.SaveChanges();

            TempData["Success"] = "✅ تم إضافة الموظف بنجاح";
            return RedirectToAction("AllEmployees");
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetEmployeeWithDetailsById(id);
            if (employee == null)
                return NotFound();

            var viewModel = _mapper.Map<EmployeeDetailsViewModel>(employee);

            return View(viewModel);
        }

        public async Task<IActionResult> AllEmployees()
        {
            var employees = await _employeeRepository.GetAllWithDepartmentAndManagerAsync();

            var viewModel = _mapper.Map<List<EmployeeDetailsViewModel>>(employees);

            return View(viewModel);
        }

    }

}
