using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
  public class LoginViewModel
  {
    [Required(ErrorMessage = "Kullanıcı Adını Giriniz")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Şifrenizi Giriniz")]
    public string? Password { get; set; }











  }
}
