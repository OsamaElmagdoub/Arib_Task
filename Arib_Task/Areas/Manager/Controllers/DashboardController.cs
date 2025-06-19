using Arib_Task.Areas.Admin.ViewModels;
using Arib_Task.Areas.Manager.ViewModels.DepartmentViewModels;
using Arib_Task.Models;
using Arib_Task.Repository.Department_Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arib_Task.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class DashboardController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DashboardController(IDepartmentRepository departmentRepository , IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAll();

            //var productCount = await _productRepository.Count();
            //var departmentCount = await _departmentRepository.Count();

            //var ordersCount = await _orderService.Count();

            var viewModel = new DashboardViewModel
            {
                //DepartmentCount = departmentCount,
                //CategoryCount = categoryCount,
                //OrdersCount = ordersCount,
            };


            return View(viewModel);
        }
        // GET: Category/Create

        public IActionResult CreateDepartment()
        {
            return View(new AddDepartmentViewModel());
        }



        //POST: Category/Create
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
                var department = _mapper.Map<Department>(addDepartmentViewModel);
                await _departmentRepository.Add(department);
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



        //// Get Products in catregory 

        //public async Task<IActionResult> ProductsInCategory(int categoryId)
        //{
        //    var category = await _categoryRepository.GetById(categoryId); // تأكد من أن لديك هذه الميثود في الريبو

        //    var products = await _productRepository.GetProductsByCategoryId(categoryId);


        //    ViewData["CategoryName"] = category?.Name; // حفظ اسم القسم في ViewData لتمريره للـ View

        //    return View(products);
        //}


        //public IActionResult ProductAddedSuccess()
        //{
        //    return View();

        //}

        //[HttpGet]
        //public async Task<IActionResult> AllProducts()
        //{
        //    var products = await _productRepository.GetAllProductsWithCategory();

        //    return View(products);
        //}



        //// GET: Product/Create 
        //[HttpGet]


        //public async Task<IActionResult> CreateProduct()
        //{
        //    var categories = await _categoryRepository.GetAll();

        //    var viewModel = new CreateProductViewModel
        //    {
        //        Categories = new SelectList(categories, "Id", "Name")

        //    };
        //    return View(viewModel);
        //}
        //[HttpGet]
        //public async Task<IActionResult> AllProductsForAdmin()
        //{
        //    var products = await _productRepository.GetAllProductsWithCategory();
        //    var viewModel = products.Select(p => new ProductListItemViewModel
        //    {
        //        Id = p.Id,
        //        Name = p.Name,
        //        ImageUrls = p.Images.Select(img => img.ImageUrl).ToList(),
        //        CategoryName = p.Category?.Name ?? "غير محدد",
        //        HasSizes = p.Sizes != null && p.Sizes.Any(),
        //        DisplayPrice = (p.Sizes != null && p.Sizes.Any())
        //    ? p.Sizes.Min(s => s.Price)
        //    : p.Price
        //    }).ToList();
        //    return View(viewModel);
        //}

        // POST: Product/Create
        //[HttpPost]
        //public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // لو فيه خطأ، رجّع الكاتيجوريز علشان يعرضهم تاني

        //        var categories = await _categoryRepository.GetAll();
        //        createProductViewModel.Categories = new SelectList(categories, "Id", "Name");

        //        return View(createProductViewModel);

        //    }

        //    // رفع الصورة لو فيه صورة
        //    try
        //    {
        //        string imageUrl = null;
        //        if (createProductViewModel.ImageFile != null)
        //        {
        //            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");
        //            Directory.CreateDirectory(folderPath);

        //            var fileName = Guid.NewGuid() + Path.GetExtension(createProductViewModel.ImageFile.FileName);
        //            var fullPath = Path.Combine(folderPath, fileName);

        //            using var stream = new FileStream(fullPath, FileMode.Create);
        //            await createProductViewModel.ImageFile.CopyToAsync(stream);

        //            imageUrl = "/images/products/" + fileName;


        //        }


        //        string videoEmbedUrl = null;
        //        if (!string.IsNullOrEmpty(createProductViewModel.VideoUrl))
        //        {
        //            videoEmbedUrl = YouTubeHelper.ConvertYouTubeUrlToEmbed(createProductViewModel.VideoUrl);
        //        }

        //        // نستخدم AutoMapper لتحويل البيانات

        //        var productDto = _mapper.Map<CreateProductDTO>(createProductViewModel);

        //        productDto.ImageUrl = imageUrl;
        //        productDto.VideoUrl = createProductViewModel.VideoUrl; // الرابط الأصلي كما هو


        //        var product = _mapper.Map<Product>(productDto);

        //        // نحفظ المنتج

        //        await _productRepository.Add(product);
        //        await _productRepository.SaveChanges();

        //        // تحقق من إضافة المنتج
        //        var addedProduct = await _productRepository.GetById(product.Id);
        //        if (addedProduct != null)
        //        {
        //            _logger.LogInformation($"تم إضافة المنتج بنجاح: {addedProduct.Name}");
        //        }

        //        // ✅ إعادة تحميل الكاتيجوريز للفيو
        //        var categories = await _categoryRepository.GetAll();

        //        var newModel = new CreateProductViewModel
        //        {
        //            Categories = new SelectList(categories, "Id", "Name")
        //        };

        //        // ✅ تفعيل عرض المودال
        //        ViewBag.ShowSuccessModal = true;
        //        return View(newModel);

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"حدث خطأ أثناء إضافة المنتج: {ex.Message}");
        //        return View("Error"); // عرض صفحة خطأ إذا حدث استثناء
        //    }

        //}



        /// أخر تحديث

        //        [HttpPost]
        //public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // لو فيه خطأ، رجّع الكاتيجوريز علشان يعرضهم تاني
        //        var categories = await _categoryRepository.GetAll();
        //        createProductViewModel.Categories = new SelectList(categories, "Id", "Name");
        //        return View(createProductViewModel);
        //    }

        //    try
        //    {
        //        string imageUrl = null;
        //        if (createProductViewModel.ImageFile != null)
        //        {
        //            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");
        //            Directory.CreateDirectory(folderPath);

        //            var fileName = Guid.NewGuid() + Path.GetExtension(createProductViewModel.ImageFile.FileName);
        //            var fullPath = Path.Combine(folderPath, fileName);

        //            using var stream = new FileStream(fullPath, FileMode.Create);
        //            await createProductViewModel.ImageFile.CopyToAsync(stream);

        //            imageUrl = "/images/products/" + fileName;
        //        }

        //        string videoEmbedUrl = null;
        //        if (!string.IsNullOrEmpty(createProductViewModel.VideoUrl))
        //        {
        //            videoEmbedUrl = YouTubeHelper.ConvertYouTubeUrlToEmbed(createProductViewModel.VideoUrl);
        //        }

        //        // إنشاء كائن Product جديد من بيانات الـ ViewModel مباشرةً
        //        var product = new Product
        //        {
        //            Name = createProductViewModel.Name,
        //            Description = createProductViewModel.Description,
        //            Price = createProductViewModel.Price,
        //            ImageUrl = imageUrl,
        //            CategoryId = createProductViewModel.CategoryId,
        //            VideoUrl = createProductViewModel.VideoUrl, // أو videoEmbedUrl لو تحب
        //            CanEditSize = createProductViewModel.CanEditSize // <-- هنا

        //        };

        //        // حفظ المنتج
        //        await _productRepository.Add(product);
        //        await _productRepository.SaveChanges();

        //                // الآن لو فيه مقاسات، نضيفها مرتبطة بالمنتج
        //                if (createProductViewModel.HasSizes && createProductViewModel.Sizes != null && createProductViewModel.Sizes.Any())
        //                {
        //                    foreach (var sizeVm in createProductViewModel.Sizes)
        //                    {
        //                        var productSize = new ProductSize
        //                        {
        //                            ProductId = product.Id,
        //                            Size = sizeVm.Size,
        //                            Price = sizeVm.Price
        //                        };

        //                        await _productSizeRepository.Add(productSize);
        //                    }
        //                    await _productSizeRepository.SaveChanges();
        //                }

        //                // إعادة تحميل الكاتيجوريز للفيو
        //                var categories = await _categoryRepository.GetAll();
        //        var newModel = new CreateProductViewModel
        //        {
        //            Categories = new SelectList(categories, "Id", "Name")
        //        };

        //        ViewBag.ShowSuccessModal = true;
        //        return View(newModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"حدث خطأ أثناء إضافة المنتج: {ex.Message}");
        //        return View("Error"); // عرض صفحة خطأ إذا حدث استثناء
        //    }
        //}


        //[HttpPost]
        //public async Task <IActionResult> SoftDeleteCategory(int id)
        //{
        //    var result = await _categoryRepository.SoftDeleteCategory(id);

        //    if (!result)
        //    {
        //        return NotFound();
        //    }
        //    TempData["SuccessMessage"] = "تم حذف القسم بنجاح (سوفت ديليت)";

        //    return RedirectToAction("Index");
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditCategory(int id, EditCategoryViewModel model)
        //{
        //    if(!ModelState.IsValid) 
        //        return View(model);

        //    var success = await _categoryRepository.UpdateCategory(id, model);
        //    if(!success)
        //    {
        //        return NotFound();
        //    }

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> EditCategory(int id)
        //{
        //    var category = await _categoryRepository.GetById(id);
        //    if (category == null)
        //        return NotFound();

        //    var model = _mapper.Map<EditCategoryViewModel>(category);
        //    return View(model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    var category = await _categoryRepository.GetById(id);
        //    if (category == null)
        //        return NotFound();

        //    var success = await _categoryRepository.DeleteCategory(id);
        //    if (!success)
        //    {
        //        return BadRequest("حدث خطأ أثناء حذف القسم.");

        //    }

        //    return RedirectToAction("Index");
        //}

    }
}
