using Microsoft.AspNetCore.Identity;

namespace AkademikProgramYonetimi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public string TamAd => $"{Ad} {Soyad}";
    }
} 