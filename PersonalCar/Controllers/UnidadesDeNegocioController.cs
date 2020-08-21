using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCar.Data;
using PersonalCar.Models.Domains;
using PersonalCar.Models.ViewModels;
using PersonalCar.Models.Services;
using PersonalCar.Models.Services.Exceptions;

namespace PersonalCar.Controllers
{
    public class UnidadesDeNegocioController : Controller
    {

        private readonly UnidadeDeNegocioService _unidadeDeNegocioService;
        private readonly ClienteService _clienteService;
        private readonly PersonalCarContext _context;

        public UnidadesDeNegocioController(UnidadeDeNegocioService unidadeDeNegocioService, ClienteService clienteService, PersonalCarContext context)
        {
            _unidadeDeNegocioService = unidadeDeNegocioService;
            _clienteService = clienteService;
            _context = context;
        }

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
            var unidades = from u in _context.UnidadeDeNegocio
                           select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                unidades = unidades.Where(u => u.NomeFantasia.Contains(searchString));
            }

            int pageSize = 2;
            var list = _unidadeDeNegocioService.FindAll();
            return View(await PaginatedList<UnidadeDeNegocio>.CreateAsync(unidades.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public IActionResult Create()
        {
            var clientes = _clienteService.FindAll();
            var viewModel = new UnidadeDeNegocioViewModel { Clientes = clientes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UnidadeDeNegocio unidadeDeNegocio)
        {
            if (!ModelState.IsValid)
            {
                return View(unidadeDeNegocio);

            }
            _unidadeDeNegocioService.Insert(unidadeDeNegocio);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _unidadeDeNegocioService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _unidadeDeNegocioService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _unidadeDeNegocioService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _unidadeDeNegocioService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Cliente> clientes = _clienteService.FindAll();
            UnidadeDeNegocioViewModel viewModel = new UnidadeDeNegocioViewModel { UnidadeDeNegocio = obj, Clientes = clientes };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UnidadeDeNegocio unidadeDeNegocio)
        {
            if (!ModelState.IsValid)
            {
                return View(unidadeDeNegocio);

            }
            if (id != unidadeDeNegocio.Id)
            {
                return BadRequest();
            }
            try
            {
                _unidadeDeNegocioService.Update(unidadeDeNegocio);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
           
        }
       
    }
}
