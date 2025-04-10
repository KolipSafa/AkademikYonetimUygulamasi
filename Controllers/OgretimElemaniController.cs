using AkademikProgramYonetimi.Data;
using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikProgramYonetimi.Controllers
{
    [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
    public class OgretimElemaniController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<OgretimElemaniController> _logger;

        public OgretimElemaniController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<OgretimElemaniController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // GET: OgretimElemani
        public async Task<IActionResult> Index()
        {
            return View(await _context.OgretimElemanlari.Include(o => o.User).ToListAsync());
        }

        // GET: OgretimElemani/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretimElemani = await _context.OgretimElemanlari
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretimElemani == null)
            {
                return NotFound();
            }

            return View(ogretimElemani);
        }

        // GET: OgretimElemani/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = await _userManager.GetUsersInRoleAsync("OgretimElemani");
            return View();
        }

        // POST: OgretimElemani/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Soyad,Unvan,Email,Telefon,UserId")] OgretimElemani ogretimElemani)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogretimElemani);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Yeni öğretim elemanı oluşturuldu: {ogretimElemani.Ad} {ogretimElemani.Soyad}");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = await _userManager.GetUsersInRoleAsync("OgretimElemani");
            return View(ogretimElemani);
        }

        // GET: OgretimElemani/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretimElemani = await _context.OgretimElemanlari.FindAsync(id);
            if (ogretimElemani == null)
            {
                return NotFound();
            }
            ViewBag.Users = await _userManager.GetUsersInRoleAsync("OgretimElemani");
            return View(ogretimElemani);
        }

        // POST: OgretimElemani/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Soyad,Unvan,Email,Telefon,UserId")] OgretimElemani ogretimElemani)
        {
            if (id != ogretimElemani.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogretimElemani);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Öğretim elemanı güncellendi: {ogretimElemani.Ad} {ogretimElemani.Soyad}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgretimElemaniExists(ogretimElemani.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = await _userManager.GetUsersInRoleAsync("OgretimElemani");
            return View(ogretimElemani);
        }

        // GET: OgretimElemani/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ogretimElemani = await _context.OgretimElemanlari
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogretimElemani == null)
            {
                return NotFound();
            }

            return View(ogretimElemani);
        }

        // POST: OgretimElemani/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogretimElemani = await _context.OgretimElemanlari.FindAsync(id);
            if (ogretimElemani != null)
            {
                // İlişkili ders programlarını kontrol et
                var dersProgramlari = await _context.DersProgramlari.AnyAsync(dp => dp.OgretimElemaniId == id);
                if (dersProgramlari)
                {
                    ModelState.AddModelError(string.Empty, "Bu öğretim elemanı programlarda kullanıldığı için silinemez.");
                    return View(ogretimElemani);
                }

                _context.OgretimElemanlari.Remove(ogretimElemani);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Öğretim elemanı silindi: {ogretimElemani.Ad} {ogretimElemani.Soyad}");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool OgretimElemaniExists(int id)
        {
            return _context.OgretimElemanlari.Any(e => e.Id == id);
        }
    }
} 