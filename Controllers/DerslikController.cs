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
    public class DerslikController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DerslikController> _logger;

        public DerslikController(ApplicationDbContext context, ILogger<DerslikController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Derslik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Derslikler.ToListAsync());
        }

        // GET: Derslik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var derslik = await _context.Derslikler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (derslik == null)
            {
                return NotFound();
            }

            return View(derslik);
        }

        // GET: Derslik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Derslik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DerslikAdi,Kapasite,Bina,Kat,Ozellikler")] Derslik derslik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(derslik);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Yeni derslik oluşturuldu: {derslik.DerslikAdi}");
                return RedirectToAction(nameof(Index));
            }
            return View(derslik);
        }

        // GET: Derslik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var derslik = await _context.Derslikler.FindAsync(id);
            if (derslik == null)
            {
                return NotFound();
            }
            return View(derslik);
        }

        // POST: Derslik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DerslikAdi,Kapasite,Bina,Kat,Ozellikler")] Derslik derslik)
        {
            if (id != derslik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(derslik);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Derslik güncellendi: {derslik.DerslikAdi}");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DerslikExists(derslik.Id))
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
            return View(derslik);
        }

        // GET: Derslik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var derslik = await _context.Derslikler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (derslik == null)
            {
                return NotFound();
            }

            return View(derslik);
        }

        // POST: Derslik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var derslik = await _context.Derslikler.FindAsync(id);
            if (derslik != null)
            {
                // İlişkili ders programlarını kontrol et
                var dersProgramlari = await _context.DersProgramlari.AnyAsync(dp => dp.DerslikId == id);
                if (dersProgramlari)
                {
                    ModelState.AddModelError(string.Empty, "Bu derslik programlarda kullanıldığı için silinemez.");
                    return View(derslik);
                }

                _context.Derslikler.Remove(derslik);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Derslik silindi: {derslik.DerslikAdi}");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool DerslikExists(int id)
        {
            return _context.Derslikler.Any(e => e.Id == id);
        }
    }
} 