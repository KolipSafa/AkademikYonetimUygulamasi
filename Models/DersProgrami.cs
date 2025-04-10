using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkademikProgramYonetimi.Models
{
    public class DersProgrami
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ders seçmek zorunludur.")]
        [Display(Name = "Ders")]
        public int DersId { get; set; }

        [ForeignKey("DersId")]
        public virtual Ders Ders { get; set; }

        [Required(ErrorMessage = "Derslik seçmek zorunludur.")]
        [Display(Name = "Derslik")]
        public int DerslikId { get; set; }

        [ForeignKey("DerslikId")]
        public virtual Derslik Derslik { get; set; }

        [Required(ErrorMessage = "Öğretim elemanı seçmek zorunludur.")]
        [Display(Name = "Öğretim Elemanı")]
        public int OgretimElemaniId { get; set; }

        [ForeignKey("OgretimElemaniId")]
        public virtual OgretimElemani OgretimElemani { get; set; }

        [Required(ErrorMessage = "Gün seçmek zorunludur.")]
        [Display(Name = "Gün")]
        public DersGunu Gun { get; set; }

        [Required(ErrorMessage = "Başlangıç saati zorunludur.")]
        [Display(Name = "Başlangıç Saati")]
        [DataType(DataType.Time)]
        public TimeSpan BaslangicSaati { get; set; }

        [Required(ErrorMessage = "Bitiş saati zorunludur.")]
        [Display(Name = "Bitiş Saati")]
        [DataType(DataType.Time)]
        public TimeSpan BitisSaati { get; set; }

        [Display(Name = "Öğrenci Sayısı")]
        [Range(0, 500, ErrorMessage = "Öğrenci sayısı 0 ile 500 arasında olmalıdır.")]
        public int OgrenciSayisi { get; set; }

        [Display(Name = "Dönem")]
        public string Donem { get; set; }

        [Display(Name = "Notlar")]
        public string Notlar { get; set; }
    }

    public enum DersGunu
    {
        [Display(Name = "Pazartesi")]
        Pazartesi = 1,
        
        [Display(Name = "Salı")]
        Sali = 2,
        
        [Display(Name = "Çarşamba")]
        Carsamba = 3,
        
        [Display(Name = "Perşembe")]
        Persembe = 4,
        
        [Display(Name = "Cuma")]
        Cuma = 5
    }
} 