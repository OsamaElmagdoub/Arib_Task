//using AutoMapper;
//using Arib_Task.Areas.Admin.Helpers;
//using Arib_Task.Areas.Admin.ViewModels.Category;
//using Arib_Task.Areas.Admin.ViewModels.ProductViewModel;
//using Arib_Task.Models;
//using Arib_Task.Repository.Category_Repository;
//using Arib_Task.Repository.ProductRepository;
//using Arib_Task.ViewModels.ProductViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace Arib_Task.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly IProductRepository _productRepository;
//        private readonly ICategoryRepository _categoryRepository;
//        private IMapper _mapper;
//        private readonly ILogger<ProductController> _logger;

//        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository,IMapper mapper,ILogger<ProductController> logger)
//        {
//            _productRepository = productRepository;
//            _categoryRepository = categoryRepository;
//            _mapper = mapper;
//            _logger = logger;
//        }
//        [HttpGet]
//        public async Task<IActionResult> Index()
//        {
//            var products = await _productRepository.GetAllProductsWithCategory();

//            var categories = await _categoryRepository.GetAll(); // تأكد عندك دالة ترجع الأقسام

//            var viewModel = products.Select(p => new ProductListItemViewModel
//            {
//                Id = p.Id,
//                Name = p.Name,
//                ImageUrls = p.Images.Select(img => img.ImageUrl).ToList(), // ✅ جمع كل الروابط
//                CategoryName = p.Category?.Name ?? "غير محدد",
//                HasSizes = p.Sizes != null && p.Sizes.Any(),
//                DisplayPrice = (p.Sizes != null && p.Sizes.Any())
//            ? p.Sizes.Min(s => s.Price)
//            : p.Price
//            }).ToList();
//            return View(viewModel);
//        }
//        //public IActionResult ProductAddedSuccess()
//        //{
//        //    return View();
//        //}


//        // GET: Product/Create
//        [HttpGet]

//        public async Task<IActionResult> CreateProduct()
//        {
//            var categories = await _categoryRepository.GetAll();

//            var viewModel = new CreateProductViewModel
//            {
//                Categories = new SelectList(categories, "Id", "Name")

//            };
//            return View( viewModel);
//        }


//        //// POST: Product/Create
//        //[HttpPost]
//        //public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
//        //{
//        //    if (!ModelState.IsValid)
//        //    {
//        //        // لو فيه خطأ، رجّع الكاتيجوريز علشان يعرضهم تاني

//        //        var categories = await _categoryRepository.GetAll();
//        //        createProductViewModel.Categories = new SelectList(categories, "Id", "Name");

//        //        return View(createProductViewModel);

//        //    }

//        //    // رفع الصورة لو فيه صورة
//        //    try
//        //    {
//        //        string imageUrl = null;
//        //        if (createProductViewModel.ImageFile != null)
//        //        {
//        //            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");
//        //            Directory.CreateDirectory(folderPath);

//        //            var fileName = Guid.NewGuid() + Path.GetExtension(createProductViewModel.ImageFile.FileName);
//        //            var fullPath = Path.Combine(folderPath, fileName);

//        //            using var stream = new FileStream(fullPath, FileMode.Create);
//        //            await createProductViewModel.ImageFile.CopyToAsync(stream);

//        //            imageUrl = "/images/products/" + fileName;


//        //        }


//        //        string videoEmbedUrl = null;
//        //        if (!string.IsNullOrEmpty(createProductViewModel.VideoUrl))
//        //        {
//        //            videoEmbedUrl = YouTubeHelper.ConvertYouTubeUrlToEmbed(createProductViewModel.VideoUrl);
//        //        }

//        //        // نستخدم AutoMapper لتحويل البيانات

//        //        var productDto = _mapper.Map<CreateProductDTO>(createProductViewModel);

//        //        productDto.ImageUrl = imageUrl;

//        //        var product = _mapper.Map<Product>(productDto);

//        //        // نحفظ المنتج

//        //        await _productRepository.Add(product);
//        //        await _productRepository.SaveChanges();

//        //        // تحقق من إضافة المنتج
//        //        var addedProduct = await _productRepository.GetById(product.Id);
//        //        if (addedProduct != null)
//        //        {
//        //            _logger.LogInformation($"تم إضافة المنتج بنجاح: {addedProduct.Name}");
//        //        }

//        //        // ✅ إعادة تحميل الكاتيجوريز للفيو
//        //        var categories = await _categoryRepository.GetAll();

//        //        var newModel = new CreateProductViewModel
//        //        {
//        //            Categories = new SelectList(categories, "Id", "Name")
//        //        };

//        //        // ✅ تفعيل عرض المودال
//        //        ViewBag.ShowSuccessModal = true;
//        //        return View(newModel);

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        _logger.LogError($"حدث خطأ أثناء إضافة المنتج: {ex.Message}");
//        //        return View("Error"); // عرض صفحة خطأ إذا حدث استثناء
//        //    }

//        //}


//        public async Task<IActionResult> Search(string keyword)
//        {
//            var result = await _productRepository.Search(keyword);
//            return View("Index",result);
//        }

//       //public IActionResult DeleteProduct (int productId)
//       // {
//       //     _productRepository.DeleteProduct(productId);
//       //     return RedirectToAction("Index");
//       // }

//        public async Task<IActionResult> ProductsByCategory(int categoryId)
//        {
//            var products = await _productRepository.GetProductsByCategoryId(categoryId);

//                var category = await _categoryRepository.GetById(categoryId);
//                ViewBag.CategoryName = category?.Name ?? "قسم غيرر معروف";

//            if(products ==null || !products.Any())
//            {
//                return View("NoProducts");
//            }
//            var productViewModels = _mapper.Map<IEnumerable<ProductListItemViewModel>>(products); 
//            return View("ProductsInCategory", productViewModels);
//        }

//        //public async Task<IActionResult> ProductDetails(int id)
//        //{
//        //    var product = await _productRepository.GetProductById(id);
//        //    if (product == null) return NotFound();

//        //    // حول رابط الفيديو لembed URL


//        //    var viewModel = _mapper.Map<ProductDetailsViewModel>(product);
//        //    viewModel.VideoEmbedUrl = YouTubeHelper.ConvertYouTubeUrlToEmbed(viewModel.VideoEmbedUrl);

//        //    return View(viewModel);


//        //}

//        public async Task<IActionResult> ProductDetails(int id)
//        {
//            var product = await _productRepository.GetProductById(id);
//            if (product == null) return NotFound();

//            _logger.LogInformation("VideoEmbedUrl after manual mapping: " + product.VideoUrl);

//            var viewModel = new ProductDetailsViewModel
//            {
//                Id = product.Id,
//                Name = product.Name,
//                Description = product.Description,
//                Price = product.Price,
//                ImageUrls = product.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>(), // ✅ الصور
//                Category = product.Category, // تأكد أن النوع متوافق مع الـ ViewModel
//                VideoEmbedUrl = string.IsNullOrEmpty(product.VideoUrl)
//                    ? string.Empty
//                    : YouTubeHelper.ConvertYouTubeUrlToEmbed(product.VideoUrl),

//                // إضافة المقاسات وتحويلها إلى ViewModel
//                Sizes = product.Sizes?.Select(s => new ProductSizeViewModel
//                {
//                    Size = s.Size,
//                    Price = s.Price,
//                    //CanEditSize = s.CanEditSize  // أو اسم الخاصية حسب الموديل عندك

//                    CanEditSize = product.CanEditSize // ✅ هنا بتاخد القيمة من المنتج الرئيسي

//                }).ToList() ?? new List<ProductSizeViewModel>(),

//                    CanEditSize = product.CanEditSize // ✅ هنا

//            };

//            return View(viewModel);
//        }

//    }
//}
