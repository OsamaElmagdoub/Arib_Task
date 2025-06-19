using System.ComponentModel.DataAnnotations;

namespace Arib_Task.Areas.Admin.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        [Required(ErrorMessage = "اسم القسم مطلوب")]
        [StringLength(100, ErrorMessage = "اسم القسم لا يجب أن يتجاوز 100 حرف")]

        public string Name { get; set; }
    }
}
