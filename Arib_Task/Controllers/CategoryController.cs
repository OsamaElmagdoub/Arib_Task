//using AutoMapper;
//using Arib_Task.Areas.Admin.ViewModels.Category;
//using Arib_Task.Models;
//using Arib_Task.Repository.Category_Repository;
//using Arib_Task.Repository.ProductRepository;
//using Microsoft.AspNetCore.Mvc;

//namespace Arib_Task.Controllers
//{
//    public class CategoryController : Controller
//    {
//        private readonly ICategoryRepository _categoryRepository;
//        private readonly IMapper _mapper;
//        private readonly IProductRepository _productRepository;

//        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper , IProductRepository productRepository)
//        {
//            _categoryRepository = categoryRepository;
//            _mapper = mapper;
//            _productRepository = productRepository;
//        }


//        //public async Task<IActionResult> Index()
//        //{
//        //    var categories = await _categoryRepository.GetAllWithProducts();
//        //    return View(categories);
//        //}
//        // GET: Category/Create

//        //public IActionResult CreateCategory()
//        //{
//        //    return View(new CreateCategoryViewModel());
//        //}

//        // POST: Category/Create
//        //[HttpPost]

//        //public async Task<IActionResult> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        return View(createCategoryViewModel);
//        //    }
//        //        try   
//        //        {
//        //            var category = _mapper.Map<Category>(createCategoryViewModel);
//        //            await _categoryRepository.Add(category);
//        //            await _categoryRepository.SaveChanges();

//        //        // تفعيل عرض المودال    
//        //        ViewBag.ShowSuccessModal = true;

//        //        return View(new CreateCategoryViewModel()); // إعادة النموذج فاضي

//        //        }

//        //    catch
//        //    {
//        //        ModelState.AddModelError("", "حدث خطأ أثناء حفظ القسم.");
//        //        return View(createCategoryViewModel);
//        //    }




//        //}

//        // Get Products in catregory 

//        public async Task<IActionResult> ProductsInCategory(int categoryId)
//        {
//            var category = await _categoryRepository.GetById(categoryId); // تأكد من أن لديك هذه الميثود في الريبو

//            var products = await _productRepository.GetProductsByCategoryId(categoryId);


//            ViewData["CategoryName"] = category?.Name; // حفظ اسم القسم في ViewData لتمريره للـ View

//            return View(products);
//        }

//    }
//}
