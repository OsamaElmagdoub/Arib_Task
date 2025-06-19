using System.ComponentModel.DataAnnotations;

namespace Arib_Task.Areas.Admin.ViewModels.ProductViewModel
{
    public class UpdateEmployeeViewModel
    {
        [Required(ErrorMessage = "المقاس مطلوب")]
        public string Size { get; set; }

        [Required(ErrorMessage = "سعر المقاس مطلوب")]
        [Range(0.01, double.MaxValue, ErrorMessage = "السعر يجب أن يكون أكبر من 0")]
        public decimal Price { get; set; }
        public bool CanEditSize { get; set; }  // خاصية جديدة لتعطيل أو تمكين التعديل

    }
}
