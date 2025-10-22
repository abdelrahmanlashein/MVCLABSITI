using Microsoft.AspNetCore.Identity;

namespace MVCLABSITI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}