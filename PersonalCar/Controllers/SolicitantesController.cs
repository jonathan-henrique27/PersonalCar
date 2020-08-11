using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PersonalCar.Models.Domains;
using PersonalCar.Models.ViewModels;
using PersonalCar.Models.Services;
using PersonalCar.Models.Services.Exceptions;

namespace PersonalWeb.Controllers
{
    public class SolicitantesController : Controller
    {
        private readonly SolicitanteService _solicitanteService;
        private readonly UnidadeDeNegocioService _unidadeDeNegocioService;

        public SolicitantesController(SolicitanteService solicitanteService, UnidadeDeNegocioService unidadeDeNegocioService)
        {
            _solicitanteService = solicitanteService;
            _unidadeDeNegocioService = unidadeDeNegocioService;
        }

        public IActionResult Index()
        {
            var list = _solicitanteService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var unidadeDeNegocios = _unidadeDeNegocioService.FindAll();
            var viewModel = new SolicitanteViewModel { UnidadeDeNegocios = unidadeDeNegocios };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Solicitante solicitante)
        {
            if (!ModelState.IsValid)
            {
                return View(solicitante);

            }
            _solicitanteService.Insert(solicitante);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _solicitanteService.FindById(id.Value);
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
            _solicitanteService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _solicitanteService.FindById(id.Value);
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
            var obj = _solicitanteService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<UnidadeDeNegocio> unidadeDeNegocios = _unidadeDeNegocioService.FindAll();
            SolicitanteViewModel viewModel = new SolicitanteViewModel { Solicitante = obj, UnidadeDeNegocios = unidadeDeNegocios };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Solicitante solicitante)
        {
            if (!ModelState.IsValid)
            {
                return View(solicitante);

            }
            if (id != solicitante.Id)
            {
                return BadRequest();
            }
            try
            {
                _solicitanteService.Update(solicitante);
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
