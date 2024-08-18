using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "Lütfen Kullanıcı adını giriniz.")]
    public string? Username { get; set; }


    [Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
    public string? Mail { get; set; }


    [Required(ErrorMessage = "Lütfen şifrenizi  giriniz.")]
    public string? Password { get; set; }



    [Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
    [Compare("Password", ErrorMessage = "Girdiğiniz şifreler aynı değil,tekrar giriniz.")]
    public string? PasswordConfirm { get; set; }



  }
}
