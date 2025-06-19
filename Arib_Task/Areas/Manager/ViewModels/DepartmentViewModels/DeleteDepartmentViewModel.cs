//using Arib_Task.Models;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.ComponentModel.DataAnnotations;

//namespace Arib_Task.Areas.Admin.ViewModels.ProductViewModel
//{
//    public class EditProductViewModel

//    {
//        [Required(ErrorMessage = "اسم المنتج مطلوب")]
//        [Display(Name = "اسم المنتج")]
//        public string Name { get; set; }

//        [Display(Name = "الوصف")]
//        public string? Description { get; set; }

//        [Required(ErrorMessage = "السعر مطلوب")]
//        [Range(0.01, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
//        [Display(Name = "السعر")]
//        public decimal Price { get; set; }

//        [Display(Name = "صور المنتج")]
//        public List<IFormFile> ImageFiles { get; set; } = new();

//        [Required(ErrorMessage = "القسم مطلوب")]
//        [Display(Name = "القسم")]
//        public int CategoryId { get; set; }

//        // قائمة الأقسام لعرضها في القائمة المنسدلة
//        public SelectList? Categories { get; set; }

//        [Display(Name = "رابط الفيديو (اختياري)")]
//        [Url(ErrorMessage = "رابط الفيديو غير صحيح")]
//        public string? VideoUrl { get; set; }

//        // خاصية لتحديد ما إذا كان المنتج يحتوي على مقاسات
//        [Display(Name = "هل يحتوي على مقاسات؟")]
//        public bool HasSizes { get; set; }

//        // إدخال المقاسات داخل النموذج
//        [Display(Name = "المقاسات")]
//        public List<ProductSizeViewModel> Sizes { get; set; } = new();

//        // هل يمكن تعديل المقاسات بعد حفظ المنتج
//        [Display(Name = "تعديل المقاسات بعد الحفظ")]
//        public bool CanEditSize { get; set; }
//    }
//}
