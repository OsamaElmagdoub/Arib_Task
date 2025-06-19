
using Arib_Task.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Arib_Task.Areas.Manager.ViewModels.EmployeeViewModel
{
    public class AddEmployeeViewModel
    {
        [Required(ErrorMessage = "الاسم الأول مطلوب")]
        [Display(Name = "الاسم الأول")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الاسم الأخير مطلوب")]
        [Display(Name = "الاسم الأخير")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "الراتب مطلوب")]
        [Range(0, double.MaxValue, ErrorMessage = "الراتب غير صالح")]
        [Display(Name = "الراتب")]
        public decimal Salary { get; set; }

        [Display(Name = "رابط الصورة (اختياري)")]
        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }


        [Required(ErrorMessage = "اختر مدير")]
        [Display(Name = "المدير")]
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "اختر قسم")]
        [Display(Name = "القسم")]
        public int DepartmentId { get; set; }

        public IEnumerable<SelectListItem>? Managers { get; set; } // علشان Dropdown
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}
