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
            ViewBag.Managers = new SelectList(await _managerRepository.GetAll(), "Id", "Name");
            ViewBag.Departments = new SelectList(await _departmentRepository.GetAll(), "Id", "Name");

            return View(new AddEmployeeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmployee(AddEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Managers = new SelectList(await _managerRepository.GetAll(), "Id", "Name");
                ViewBag.Departments = new SelectList(await _departmentRepository.GetAll(), "Id", "Name");
                return View(model);
            }


            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salary = model.Salary,
                //ImageUrl = imageName,
                DepartmentId = model.DepartmentId,
                ManagerId = model.ManagerId
            };

            await _employeeRepository.Add(employee);

            TempData["Success"] = "تمت إضافة الموظف بنجاح ✅";
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetEmployeeWithDetailsById(id);
            if (employee == null)
                return NotFound();

            var viewModel = _mapper.Map<EmployeeDetailsViewModel>(employee);

            return View(viewModel);
        }


    }

    //public IActionResult DeleteProduct(int productId)
    //{
    //    _productRepository.DeleteProduct(productId);
    //    return RedirectToAction("Index");
    //}

    //public async Task<IActionResult> ProductDetails(int id)
    //{
    //    var product = await _productRepository.GetProductById(id);
    //    if (product == null) return NotFound();

    //    _logger.LogInformation("VideoEmbedUrl after manual mapping: " + product.VideoUrl);

    //    var viewModel = new ProductDetailsViewModel
    //    {
    //        Id = product.Id,
    //        Name = product.Name,
    //        Description = product.Description,
    //        Price = product.Price,
    //        ImageUrls = product.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>(), // ✅ الصور
    //        Category = product.Category, // تأكد أن النوع متوافق مع الـ ViewModel
    //        VideoEmbedUrl = string.IsNullOrEmpty(product.VideoUrl)
    //            ? string.Empty
    //            : YouTubeHelper.ConvertYouTubeUrlToEmbed(product.VideoUrl),

    //        // إضافة المقاسات وتحويلها إلى ViewModel
    //        Sizes = product.Sizes?.Select(s => new ProductSizeViewModel
    //        {
    //            Size = s.Size,
    //            Price = s.Price,
    //            CanEditSize = s.CanEditSize  // أو اسم الخاصية حسب الموديل عندك
    //        }).ToList() ?? new List<ProductSizeViewModel>()
    //    };

    //    return View(viewModel);
    //}


    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> EditProduct(int id, EditProductViewModel model)
    //    {
    //        if (!ModelState.IsValid)
    //            return View(model);

    //        var success = await _productRepository.UpdateProduct(id, model);
    //        if (!success)
    //        {
    //            return NotFound();
    //        }

    //        return RedirectToAction("Index");
    //    }

    //}
}
