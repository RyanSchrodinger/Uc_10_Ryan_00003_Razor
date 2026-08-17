using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uc_10_Ryan_00003_Razor.Data;
using Uc_10_Ryan_00003_Razor.Models;

namespace Uc_10_Ryan_00003_Razor.Controllers
{
    public class CoffesController : Controller
    {
        private readonly Uc_10_Ryan_00003_RazorContext _context;

        public CoffesController(Uc_10_Ryan_00003_RazorContext context)
        {
            _context = context;
        }

        // GET: Coffes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coffe.ToListAsync());
        }

        // GET: Coffes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // GET: Coffes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coffes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco")] Coffe coffe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coffe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coffe);
        }

        // GET: Coffes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe.FindAsync(id);
            if (coffe == null)
            {
                return NotFound();
            }
            return View(coffe);
        }

        // POST: Coffes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco")] Coffe coffe)
        {
            if (id != coffe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coffe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoffeExists(coffe.Id))
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
            return View(coffe);
        }

        // GET: Coffes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coffe = await _context.Coffe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coffe == null)
            {
                return NotFound();
            }

            return View(coffe);
        }

        // POST: Coffes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coffe = await _context.Coffe.FindAsync(id);
            if (coffe != null)
            {
                _context.Coffe.Remove(coffe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoffeExists(int id)
        {
            return _context.Coffe.Any(e => e.Id == id);
        }
    }
}
