using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCar.Data;
using PersonalCar.Models.Domains;
using PersonalCar.Models.Services;
using PersonalCar.Models.ViewModels;

namespace PersonalCar.Controllers
{
    public class ClientesController : Controller
    {
        private readonly PersonalCarContext _context;
        private readonly UnidadeDeNegocioService _unidadeDeNegocioService;

        public ClientesController(PersonalCarContext context, UnidadeDeNegocioService unidadeDeNegocioService)
        {
            _unidadeDeNegocioService = unidadeDeNegocioService;
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index(
                string sortOrder,
                string currentFilter,
                string searchString,
                int? pageNumber)
        {
                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
                ViewData["CurrentFilter"] = searchString;
  
            var clientes = from c in _context.Cliente
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes.Where(c => c.NomeFantasia.Contains(searchString));
            }
           
            int pageSize = 3;
            return View(await PaginatedList<Cliente>.CreateAsync(clientes.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .Include(c => c.UnidadeDeNegocios)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            var unidades = _unidadeDeNegocioService.FindAll();
            var viewModel = new ClienteViewModel { UnidadeDeNegocios = unidades };
            return View(viewModel);
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeFantasia")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.FindAsync(Id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,NomeFantasia")] Cliente cliente)
        {
            if (Id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int Id)
        {
            return _context.Cliente.Any(e => e.Id == Id);
        }
    }
}
