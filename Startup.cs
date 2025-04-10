using AkademikProgramYonetimi.Data;
using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AkademikProgramYonetimi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Veritabanı bağlantısı ekle
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Identity servislerini ekle
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Cookie ayarları
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            // Her durumda geliştirici hata sayfasını etkinleştir (geçici olarak)
            app.UseDeveloperExceptionPage();
            
            /* if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            } */

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            // Veritabanını otomatik oluştur ve başlangıç verilerini ekle
            try
            {
                CreateDatabase(serviceProvider).Wait();
            }
            catch (Exception ex)
            {
                var logger = app.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                logger.LogError(ex, "Veritabanı başlatma hatası");
                // Hatayı konsola da yazdır
                Console.WriteLine("HATA: " + ex.ToString());
            }
        }

        private async Task CreateDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    // Migration olmadan veritabanını oluştur
                    context.Database.EnsureCreated();

                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await SeedData.Initialize(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<Microsoft.Extensions.Logging.ILogger<Startup>>();
                    logger.LogError(ex, "Veritabanı başlatma hatası");
                }
            }
        }
    }
} 