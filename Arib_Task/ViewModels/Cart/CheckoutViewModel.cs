using System.ComponentModel.DataAnnotations;

namespace Arib_Task.ViewModels.Cart
{
    public class CheckoutViewModel
    {
        // بيانات المستخدم
        [Required(ErrorMessage = "من فضلك أدخل الاسم الكامل")]

        public string FullName { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل العنوان")]
        public string Address { get; set; }

        [Required(ErrorMessage = "من فضلك أدخل رقم الهاتف")]
        [Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        public string PhoneNumber { get; set; }

        public List<CartItemViewModel> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
