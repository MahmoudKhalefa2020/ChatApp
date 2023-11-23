using System.ComponentModel.DataAnnotations;

namespace ImoApp.ViewModel;

public class UserRegister
{
    [Required]
    public string Name { get; set; }
    [DataType(DataType.Password)]
    [Required]
    [Compare("PsswordConfirmed")]
    public string Password { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string PsswordConfirmed { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string PhoneNumberConfirmed { get; set; }
}

