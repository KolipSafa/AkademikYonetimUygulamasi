using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AkademikProgramYonetimi.Models
{
    public class Derslik
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Derslik adı zorunludur.")]
        [Display(Name = "Derslik Adı")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Derslik adı 2 ile 50 karakter arasında olmalıdır.")]
        public string DerslikAdi { get; set; }

        [Required(ErrorMessage = "Kapasite zorunludur.")]
        [Display(Name = "Kapasite")]
        [Range(1, 500, ErrorMessage = "Kapasite 1 ile 500 arasında olmalıdır.")]
        public int Kapasite { get; set; }

        [Display(Name = "Bina")]
        public string Bina { get; set; }

        [Display(Name = "Kat")]
        public string Kat { get; set; }

        [Display(Name = "Özellikler")]
        public string Ozellikler { get; set; }

        // Navigation properties
        public virtual ICollection<DersProgrami> DersProgramlari { get; set; }
    }
} 