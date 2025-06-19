using System.ComponentModel.DataAnnotations;

namespace Arib_Task.ViewModels.AccountViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        [Display(Name = "اسم المستخدم مطلوب")] 
        
        public string UserName { get; set; }

      
        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        
    }
}
