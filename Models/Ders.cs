using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkademikProgramYonetimi.Models
{
    public class Ders
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ders kodu zorunludur.")]
        [Display(Name = "Ders Kodu")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Ders kodu 2 ile 10 karakter arasında olmalıdır.")]
        public string DersKodu { get; set; }

        [Required(ErrorMessage = "Ders adı zorunludur.")]
        [Display(Name = "Ders Adı")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Ders adı 3 ile 100 karakter arasında olmalıdır.")]
        public string DersAdi { get; set; }

        [Display(Name = "Kredi")]
        [Range(1, 10, ErrorMessage = "Kredi 1 ile 10 arasında olmalıdır.")]
        public int Kredi { get; set; }

        [Display(Name = "AKTS")]
        [Range(1, 30, ErrorMessage = "AKTS 1 ile 30 arasında olmalıdır.")]
        public int AKTS { get; set; }

        [Display(Name = "Dönem")]
        public string Donem { get; set; }

        [Display(Name = "Ön Koşul")]
        public string OnKosul { get; set; }

        // Navigation properties
        public virtual ICollection<DersProgrami> DersProgramlari { get; set; }
    }
} 