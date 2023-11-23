using Microsoft.AspNetCore.Identity;

namespace ImoApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string PhoneNumberConfirmed { get; set; }
        public string PasswordConfirmed { get; set; }
    }
}
