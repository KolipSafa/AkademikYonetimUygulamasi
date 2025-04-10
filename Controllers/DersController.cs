using AkademikProgramYonetimi.Data;
using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class DersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DersController> _logger;

        public DersController(ApplicationDbContext context, ILogger<DersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Ders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dersler.ToListAsync());
        }

        // GET: Ders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // GET: Ders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DersKodu,DersAdi,Kredi,AKTS,Donem,OnKosul")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ders);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Yeni ders oluşturuldu: {ders.DersKodu} - {ders.DersAdi}");
                return RedirectToAction(nameof(Index));
            }
            return View(ders);
        }

        // GET: Ders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler.FindAsync(id);
            if (ders == null)
            {
                return NotFound();
            }
            return View(ders);
        }

        // POST: Ders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DersKodu,DersAdi,Kredi,AKTS,Donem,OnKosul")] Ders ders)
        {
            if (id != ders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ders);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Ders güncellendi: {ders.DersKodu} - {ders.DersAdi}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersExists(ders.Id))
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
            return View(ders);
        }

        // GET: Ders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ders = await _context.Dersler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ders == null)
            {
                return NotFound();
            }

            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ders = await _context.Dersler.FindAsync(id);
            if (ders != null)
            {
                // İlişkili ders programlarını kontrol et
                var dersProgramlari = await _context.DersProgramlari.AnyAsync(dp => dp.DersId == id);
                if (dersProgramlari)
                {
                    ModelState.AddModelError(string.Empty, "Bu ders programlarda kullanıldığı için silinemez.");
                    return View(ders);
                }

                _context.Dersler.Remove(ders);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Ders silindi: {ders.DersKodu} - {ders.DersAdi}");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool DersExists(int id)
        {
            return _context.Dersler.Any(e => e.Id == id);
        }
    }
} 