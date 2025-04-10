using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkademikProgramYonetimi.Models
{
    public class OgretimElemani
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Öğretim elemanı adı zorunludur.")]
        [Display(Name = "Ad")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2 ile 50 karakter arasında olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Öğretim elemanı soyadı zorunludur.")]
        [Display(Name = "Soyad")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyad 2 ile 50 karakter arasında olmalıdır.")]
        public string Soyad { get; set; }

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        [Display(Name = "Unvan")]
        public string Unvan { get; set; }

        [Display(Name = "E-posta")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }

        [Display(Name = "Kullanıcı Kimliği")]
        public string UserId { get; set; } // Identity kullanıcısı ile ilişkilendirmek için

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        // Navigation properties
        public virtual ICollection<DersProgrami> DersProgramlari { get; set; }
    }
} 