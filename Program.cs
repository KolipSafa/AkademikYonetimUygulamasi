using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace AkademikProgramYonetimi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Uygulama başlatılıyor...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Uygulama başlatılırken hata: {ex.Message}");
                Debug.WriteLine($"Hata detayları: {ex}");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:7000", "https://localhost:7001");
                });
    }
} 