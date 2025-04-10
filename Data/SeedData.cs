using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AkademikProgramYonetimi.Data
{
    public static class SeedData
    {
        public static async Task Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Rolleri oluştur
            string[] roleNames = { "BolumBaskani", "OgretimElemani", "BolumSekreteri" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Bölüm Başkanı Kullanıcısı oluştur
            var bolumBaskani = new ApplicationUser
            {
                UserName = "bolumbaskani@example.com",
                Email = "bolumbaskani@example.com",
                EmailConfirmed = true,
                Ad = "Bölüm",
                Soyad = "Başkanı",
                PhoneNumber = "5551112233",
                PhoneNumberConfirmed = true
            };

            var bolumBaskaniKullanici = await userManager.FindByEmailAsync(bolumBaskani.Email);
            if (bolumBaskaniKullanici == null)
            {
                var createBolumBaskani = await userManager.CreateAsync(bolumBaskani, "P@ssw0rd1");
                if (createBolumBaskani.Succeeded)
                {
                    await userManager.AddToRoleAsync(bolumBaskani, "BolumBaskani");
                }
            }

            // Bölüm Sekreteri Kullanıcısı oluştur
            var bolumSekreteri = new ApplicationUser
            {
                UserName = "bolumsekreteri@example.com",
                Email = "bolumsekreteri@example.com",
                EmailConfirmed = true,
                Ad = "Bölüm",
                Soyad = "Sekreteri",
                PhoneNumber = "5551112244",
                PhoneNumberConfirmed = true
            };

            var bolumSekreteriKullanici = await userManager.FindByEmailAsync(bolumSekreteri.Email);
            if (bolumSekreteriKullanici == null)
            {
                var createBolumSekreteri = await userManager.CreateAsync(bolumSekreteri, "P@ssw0rd1");
                if (createBolumSekreteri.Succeeded)
                {
                    await userManager.AddToRoleAsync(bolumSekreteri, "BolumSekreteri");
                }
            }

            // Öğretim Elemanı Kullanıcısı oluştur
            var ogretimElemani = new ApplicationUser
            {
                UserName = "ogretimelemani@example.com",
                Email = "ogretimelemani@example.com",
                EmailConfirmed = true,
                Ad = "Öğretim",
                Soyad = "Elemanı",
                PhoneNumber = "5551112255",
                PhoneNumberConfirmed = true
            };

            var ogretimElemaniKullanici = await userManager.FindByEmailAsync(ogretimElemani.Email);
            if (ogretimElemaniKullanici == null)
            {
                var createOgretimElemani = await userManager.CreateAsync(ogretimElemani, "P@ssw0rd1");
                if (createOgretimElemani.Succeeded)
                {
                    await userManager.AddToRoleAsync(ogretimElemani, "OgretimElemani");
                }
            }
        }
    }
} 