using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCar.Data;
using PersonalCar.Models.Domains;

namespace PersonalCar.Controllers
{
    public class CentroDeCustosController : Controller
    {
        private readonly PersonalCarContext _context;

        public CentroDeCustosController(PersonalCarContext context)
        {
            _context = context;
        }

        // GET: CentroDeCustos
        public async Task<IActionResult> Index(
            string sortOrder, 
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var centroDeCustos = from c in _context.CentroDeCusto
                                 select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                centroDeCustos = centroDeCustos.Where(c => c.Nome.Contains(searchString));
            }

            int pageSize = 1;
            return View(await PaginatedList<CentroDeCusto>.CreateAsync(centroDeCustos.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: CentroDeCustos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDeCusto = await _context.CentroDeCusto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroDeCusto == null)
            {
                return NotFound();
            }

            return View(centroDeCusto);
        }

        // GET: CentroDeCustos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroDeCustos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] CentroDeCusto centroDeCusto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroDeCusto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(centroDeCusto);
        }

        // GET: CentroDeCustos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDeCusto = await _context.CentroDeCusto.FindAsync(id);
            if (centroDeCusto == null)
            {
                return NotFound();
            }
            return View(centroDeCusto);
        }

        // POST: CentroDeCustos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] CentroDeCusto centroDeCusto)
        {
            if (id != centroDeCusto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroDeCusto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroDeCustoExists(centroDeCusto.Id))
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
            return View(centroDeCusto);
        }

        // GET: CentroDeCustos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroDeCusto = await _context.CentroDeCusto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centroDeCusto == null)
            {
                return NotFound();
            }

            return View(centroDeCusto);
        }

        // POST: CentroDeCustos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroDeCusto = await _context.CentroDeCusto.FindAsync(id);
            _context.CentroDeCusto.Remove(centroDeCusto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroDeCustoExists(int id)
        {
            return _context.CentroDeCusto.Any(e => e.Id == id);
        }
    }
}
