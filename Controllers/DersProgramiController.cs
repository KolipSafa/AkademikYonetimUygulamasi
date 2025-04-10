using AkademikProgramYonetimi.Data;
using AkademikProgramYonetimi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkademikProgramYonetimi.Controllers
{
    [Authorize]
    public class DersProgramiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DersProgramiController> _logger;

        public DersProgramiController(ApplicationDbContext context, ILogger<DersProgramiController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: DersProgram
        public async Task<IActionResult> Index()
        {
            var dersProgramlari = await _context.DersProgramlari
                .Include(d => d.Ders)
                .Include(d => d.Derslik)
                .Include(d => d.OgretimElemani)
                .ToListAsync();

            return View(dersProgramlari);
        }

        // GET: DersProgram/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgram = await _context.DersProgramlari
                .Include(d => d.Ders)
                .Include(d => d.Derslik)
                .Include(d => d.OgretimElemani)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dersProgram == null)
            {
                return NotFound();
            }

            return View(dersProgram);
        }

        // GET: DersProgram/Create
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Dersler = new SelectList(await _context.Dersler.ToListAsync(), "Id", "DersAdi");
            ViewBag.Derslikler = new SelectList(await _context.Derslikler.ToListAsync(), "Id", "DerslikAdi");
            ViewBag.OgretimElemanlari = new SelectList(await _context.OgretimElemanlari.ToListAsync(), "Id", "TamAd");
            ViewBag.Gunler = Enum.GetValues(typeof(DersGunu))
                .Cast<DersGunu>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                });

            return View();
        }

        // POST: DersProgram/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> Create([Bind("DersId,DerslikId,OgretimElemaniId,Gun,BaslangicSaati,BitisSaati,OgrenciSayisi,Donem,Notlar")] DersProgrami dersProgram)
        {
            if (ModelState.IsValid)
            {
                // Çakışma kontrolü
                bool cakismaVar = await CakismaKontrol(dersProgram);
                if (cakismaVar)
                {
                    ModelState.AddModelError(string.Empty, "Bu zaman diliminde seçilen derslik veya öğretim elemanı için çakışma bulunmaktadır.");
                    await FormSelectListleriDoldur();
                    return View(dersProgram);
                }

                // Derslik kapasitesi kontrolü
                var derslik = await _context.Derslikler.FindAsync(dersProgram.DerslikId);
                if (derslik != null && dersProgram.OgrenciSayisi > derslik.Kapasite)
                {
                    ModelState.AddModelError(string.Empty, $"Derslik kapasitesi ({derslik.Kapasite}) öğrenci sayısından ({dersProgram.OgrenciSayisi}) küçük olamaz.");
                    await FormSelectListleriDoldur();
                    return View(dersProgram);
                }

                _context.Add(dersProgram);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Yeni ders programı oluşturuldu.");
                return RedirectToAction(nameof(Index));
            }
            
            await FormSelectListleriDoldur();
            return View(dersProgram);
        }

        // GET: DersProgram/Edit/5
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgram = await _context.DersProgramlari.FindAsync(id);
            if (dersProgram == null)
            {
                return NotFound();
            }

            await FormSelectListleriDoldur();
            return View(dersProgram);
        }

        // POST: DersProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DersId,DerslikId,OgretimElemaniId,Gun,BaslangicSaati,BitisSaati,OgrenciSayisi,Donem,Notlar")] DersProgrami dersProgram)
        {
            if (id != dersProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Çakışma kontrolü (kendi ID'sini hariç tutarak)
                bool cakismaVar = await CakismaKontrol(dersProgram, id);
                if (cakismaVar)
                {
                    ModelState.AddModelError(string.Empty, "Bu zaman diliminde seçilen derslik veya öğretim elemanı için çakışma bulunmaktadır.");
                    await FormSelectListleriDoldur();
                    return View(dersProgram);
                }

                // Derslik kapasitesi kontrolü
                var derslik = await _context.Derslikler.FindAsync(dersProgram.DerslikId);
                if (derslik != null && dersProgram.OgrenciSayisi > derslik.Kapasite)
                {
                    ModelState.AddModelError(string.Empty, $"Derslik kapasitesi ({derslik.Kapasite}) öğrenci sayısından ({dersProgram.OgrenciSayisi}) küçük olamaz.");
                    await FormSelectListleriDoldur();
                    return View(dersProgram);
                }

                try
                {
                    _context.Update(dersProgram);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Ders programı güncellendi (ID: {dersProgram.Id})");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DersProgramiExists(dersProgram.Id))
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
            
            await FormSelectListleriDoldur();
            return View(dersProgram);
        }

        // GET: DersProgram/Delete/5
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dersProgram = await _context.DersProgramlari
                .Include(d => d.Ders)
                .Include(d => d.Derslik)
                .Include(d => d.OgretimElemani)
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (dersProgram == null)
            {
                return NotFound();
            }

            return View(dersProgram);
        }

        // POST: DersProgram/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BolumBaskani,BolumSekreteri")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dersProgram = await _context.DersProgramlari.FindAsync(id);
            if (dersProgram != null)
            {
                _context.DersProgramlari.Remove(dersProgram);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Ders programı silindi (ID: {id})");
            }
            
            return RedirectToAction(nameof(Index));
        }

        // Haftalık Ders Programı (Derslikler bazında)
        public async Task<IActionResult> HaftalikProgram()
        {
            var dersProgramlari = await _context.DersProgramlari
                .Include(d => d.Ders)
                .Include(d => d.Derslik)
                .Include(d => d.OgretimElemani)
                .OrderBy(d => d.DerslikId)
                .ThenBy(d => d.Gun)
                .ThenBy(d => d.BaslangicSaati)
                .ToListAsync();

            return View(dersProgramlari);
        }

        // Öğretim Elemanı Bazında Ders Programı
        public async Task<IActionResult> OgretimElemaniProgram(int? ogretimElemaniId)
        {
            ViewBag.OgretimElemanlari = new SelectList(await _context.OgretimElemanlari.ToListAsync(), "Id", "TamAd");

            var query = _context.DersProgramlari
                .Include(d => d.Ders)
                .Include(d => d.Derslik)
                .Include(d => d.OgretimElemani)
                .OrderBy(d => d.Gun)
                .ThenBy(d => d.BaslangicSaati)
                .AsQueryable();

            if (ogretimElemaniId.HasValue)
            {
                query = query.Where(d => d.OgretimElemaniId == ogretimElemaniId.Value);
            }

            return View(await query.ToListAsync());
        }

        private async Task<bool> CakismaKontrol(DersProgrami yeniProgram, int? haricTutulacakId = null)
        {
            // 1. Derslik çakışması kontrolü
            var derslikCakisma = await _context.DersProgramlari
                .Where(dp => dp.DerslikId == yeniProgram.DerslikId &&
                            dp.Gun == yeniProgram.Gun &&
                            ((dp.BaslangicSaati <= yeniProgram.BaslangicSaati && dp.BitisSaati > yeniProgram.BaslangicSaati) ||
                            (dp.BaslangicSaati < yeniProgram.BitisSaati && dp.BitisSaati >= yeniProgram.BitisSaati) ||
                            (dp.BaslangicSaati >= yeniProgram.BaslangicSaati && dp.BitisSaati <= yeniProgram.BitisSaati)) &&
                            (haricTutulacakId == null || dp.Id != haricTutulacakId))
                .AnyAsync();

            if (derslikCakisma)
            {
                return true;
            }

            // 2. Öğretim elemanı çakışması kontrolü
            var ogretimElemaniCakisma = await _context.DersProgramlari
                .Where(dp => dp.OgretimElemaniId == yeniProgram.OgretimElemaniId &&
                            dp.Gun == yeniProgram.Gun &&
                            ((dp.BaslangicSaati <= yeniProgram.BaslangicSaati && dp.BitisSaati > yeniProgram.BaslangicSaati) ||
                            (dp.BaslangicSaati < yeniProgram.BitisSaati && dp.BitisSaati >= yeniProgram.BitisSaati) ||
                            (dp.BaslangicSaati >= yeniProgram.BaslangicSaati && dp.BitisSaati <= yeniProgram.BitisSaati)) &&
                            (haricTutulacakId == null || dp.Id != haricTutulacakId))
                .AnyAsync();

            return ogretimElemaniCakisma;
        }

        private async Task FormSelectListleriDoldur()
        {
            ViewBag.Dersler = new SelectList(await _context.Dersler.ToListAsync(), "Id", "DersAdi");
            ViewBag.Derslikler = new SelectList(await _context.Derslikler.ToListAsync(), "Id", "DerslikAdi");
            ViewBag.OgretimElemanlari = new SelectList(await _context.OgretimElemanlari.ToListAsync(), "Id", "TamAd");
            ViewBag.Gunler = Enum.GetValues(typeof(DersGunu))
                .Cast<DersGunu>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                });
        }

        private bool DersProgramiExists(int id)
        {
            return _context.DersProgramlari.Any(e => e.Id == id);
        }
    }
} 