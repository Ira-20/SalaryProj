using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayScaleApp;

namespace PayScaleApp.Controllers
{
    public class SalBandsController : Controller
    {
        private readonly PayScaleDbContext _context;

        public SalBandsController(PayScaleDbContext context)
        {
            _context = context;
        }

        // GET: SalBands
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalBands.ToListAsync());
        }

        // GET: SalBands/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salBand = await _context.SalBands
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (salBand == null)
            {
                return NotFound();
            }

            return View(salBand);
        }

        // GET: SalBands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalBands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayBand,BasicSalary")] SalBand salBand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salBand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salBand);
        }

        // GET: SalBands/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salBand = await _context.SalBands.FindAsync(id);
            if (salBand == null)
            {
                return NotFound();
            }
            return View(salBand);
        }

        // POST: SalBands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayBand,BasicSalary")] SalBand salBand)
        {
            if (id != salBand.PayBand)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salBand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalBandExists(salBand.PayBand))
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
            return View(salBand);
        }

        // GET: SalBands/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salBand = await _context.SalBands
                .FirstOrDefaultAsync(m => m.PayBand == id);
            if (salBand == null)
            {
                return NotFound();
            }

            return View(salBand);
        }

        // POST: SalBands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var salBand = await _context.SalBands.FindAsync(id);
            _context.SalBands.Remove(salBand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalBandExists(string id)
        {
            return _context.SalBands.Any(e => e.PayBand == id);
        }
    }
}
