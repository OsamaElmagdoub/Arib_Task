

using Arib_Task.Areas.Manager.ViewModels.DepartmentViewModels;
using Arib_Task.Models;
using Arib_Task.Repository.Department_Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arib_Task.Areas.Manager.Controllers
{
    [Area("Manager")]

    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
        // GET: Category/Create

        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllWithEmployees();
            return View(departments);
        }
        public IActionResult CreateDepartment()
        {
            return View(new AddDepartmentViewModel());
        }
        // POST: Category/Create
        [HttpPost]

        public async Task<IActionResult> CreateDepartment(AddDepartmentViewModel addDepartmentViewModel)
        {

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); 
                }
                return View(addDepartmentViewModel);
            }
            try
            {
                var category = _mapper.Map<Department>(addDepartmentViewModel);
                await _departmentRepository.Add(category);
                await _departmentRepository.SaveChanges();

                ViewBag.ShowSuccessModal = true;

                return View(new AddDepartmentViewModel()); // إعادة النموذج فاضي

            }

            catch
            {
                ModelState.AddModelError("", "حدث خطأ أثناء حفظ القسم.");
                return View(addDepartmentViewModel);
            }


        }

//        [HttpPost]
//        public async Task<IActionResult> SoftDeleteCategory(int id)
//        {
//            var result = await _categoryRepository.SoftDeleteCategory(id);

//            if (!result)
//            {
//                return NotFound();
//            }
//            TempData["SuccessMessage"] = "تم حذف القسم بنجاح (سوفت ديليت)";

//            return RedirectToAction("Index");
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> EditCategory(int id, EditCategoryViewModel model)
//        {
//            if (!ModelState.IsValid)
//                return View(model);

//            var success = await _categoryRepository.UpdateCategory(id, model);
//            if (!success)
//            {
//                return NotFound();
//            }

//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public async Task<IActionResult> EditCategory(int id)
//        {
//            var category = await _categoryRepository.GetById(id);
//            if (category == null)
//                return NotFound();

//            var model = _mapper.Map<EditCategoryViewModel>(category);
//            return View(model);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteCategory(int id)
//        {
//            var category = await _categoryRepository.GetById(id);
//            if (category == null)
//                return NotFound();

//            var success = await _categoryRepository.DeleteCategory(id);
//            if (!success)
//            {
//                return BadRequest("حدث خطأ أثناء حذف القسم.");

//            }

//            return RedirectToAction("Index");
//        }
    }
}
