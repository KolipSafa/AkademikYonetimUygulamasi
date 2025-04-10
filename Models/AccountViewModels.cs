using System.ComponentModel.DataAnnotations;

namespace AkademikProgramYonetimi.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifreyi Onayla")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Rol seçilmelidir.")]
        [Display(Name = "Rol")]
        public string Role { get; set; }
    }
} 