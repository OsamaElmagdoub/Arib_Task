using Microsoft.AspNetCore.Identity;

namespace Arib_Task.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
