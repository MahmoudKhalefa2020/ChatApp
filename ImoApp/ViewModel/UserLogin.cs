using System.ComponentModel.DataAnnotations;

namespace ImoApp.ViewModel
{
    public class UserLogin
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
