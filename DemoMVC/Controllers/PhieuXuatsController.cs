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
    public class PhieuXuatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhieuXuatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhieuXuats
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhieuXuats.ToListAsync());
        }

        // GET: PhieuXuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats
                .FirstOrDefaultAsync(m => m.MaPX == id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return View(phieuXuat);
        }

        // GET: PhieuXuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhieuXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(PhieuXuat phieuXuat)
       {
    if (ModelState.IsValid)
    {
        // 1. Kiểm tra xem trong kho có đủ hàng không
        foreach (var item in phieuXuat.ChiTietPhieuXuats)
        {
            var thietBi = await _context.ThietBis.FindAsync(item.MaTB);
            if (thietBi == null || thietBi.SoLuongTon < item.SoLuong)
            {
                ModelState.AddModelError("", $"Thiết bị {thietBi?.TenTB} không đủ hàng để xuất!");
                return View(phieuXuat);
            }
            // 2. Thực hiện trừ số lượng tồn kho
            thietBi.SoLuongTon -= item.SoLuong;
            _context.Update(thietBi);
        }

        _context.Add(phieuXuat);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(phieuXuat);
       }
 
        // GET: PhieuXuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats.FindAsync(id);
            if (phieuXuat == null)
            {
                return NotFound();
            }
            return View(phieuXuat);
        }

        // POST: PhieuXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPX,NgayXuat,TenKhachHang,GhiChu")] PhieuXuat phieuXuat)
        {
            if (id != phieuXuat.MaPX)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuXuatExists(phieuXuat.MaPX))
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
            return View(phieuXuat);
        }

        // GET: PhieuXuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuXuat = await _context.PhieuXuats
                .FirstOrDefaultAsync(m => m.MaPX == id);
            if (phieuXuat == null)
            {
                return NotFound();
            }

            return View(phieuXuat);
        }

        // POST: PhieuXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phieuXuat = await _context.PhieuXuats.FindAsync(id);
            if (phieuXuat != null)
            {
                _context.PhieuXuats.Remove(phieuXuat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuXuatExists(int id)
        {
            return _context.PhieuXuats.Any(e => e.MaPX == id);
        }
    }
}
