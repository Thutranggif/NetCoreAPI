using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models.Entities;

namespace DemoMVC.Controllers
{
    public class ThietBisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThietBisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThietBis
        
        public async Task<IActionResult> Index(string? searchString)
        {
    // 1. Khởi tạo truy vấn bao gồm cả bảng Loại thiết bị
    var query = _context.ThietBis.Include(t => t.LoaiThietBi).AsQueryable();

    // 2. Nếu người dùng có nhập từ khóa tìm kiếm
    if (!string.IsNullOrEmpty(searchString))
    {
        // Tìm theo tên thiết bị HOẶC tên loại thiết bị
        query = query.Where(s => s.TenTB.Contains(searchString) 
                              || s.LoaiThietBi.TenLoai.Contains(searchString));
    }

    // 3. Lưu lại từ khóa vào ViewData để hiển thị lại trên ô Input ở View
    ViewData["CurrentFilter"] = searchString;

    return View(await query.ToListAsync());
      }

        // GET: ThietBis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis
                .Include(t => t.LoaiThietBi)
                .FirstOrDefaultAsync(m => m.MaTB == id);
            if (thietBi == null)
            {
                return NotFound();
            }

            return View(thietBi);
        }

        // GET: ThietBis/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiThietBis, "MaLoai", "TenLoai");
            return View();
        }

        // POST: ThietBis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTB,TenTB,SoLuongTon,Gia,MaLoai")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thietBi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiThietBis, "MaLoai", "TenLoai", thietBi.MaLoai);
            return View(thietBi);
        }

        // GET: ThietBis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiThietBis, "MaLoai", "TenLoai", thietBi.MaLoai);
            return View(thietBi);
        }

        // POST: ThietBis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaTB,TenTB,SoLuongTon,Gia,MaLoai")] ThietBi thietBi)
        {
            if (id != thietBi.MaTB)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thietBi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThietBiExists(thietBi.MaTB))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiThietBis, "MaLoai", "TenLoai", thietBi.MaLoai);
            return View(thietBi);
        }

        // GET: ThietBis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thietBi = await _context.ThietBis
                .Include(t => t.LoaiThietBi)
                .FirstOrDefaultAsync(m => m.MaTB == id);
            if (thietBi == null)
            {
                return NotFound();
            }

            return View(thietBi);
        }

        // POST: ThietBis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi != null)
            {
                _context.ThietBis.Remove(thietBi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThietBiExists(int id)
        {
            return _context.ThietBis.Any(e => e.MaTB == id);
        }
    }
}
