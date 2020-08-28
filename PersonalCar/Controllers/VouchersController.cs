using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalCar.Data;
using PersonalCar.Models.Domains;
using PersonalCar.Models.Services;
using PersonalCar.Models.ViewModels;

namespace PersonalCar.Controllers
{
    public class VouchersController : Controller
    {
        private readonly PersonalCarContext _context;
        
        private readonly UnidadeDeNegocioService _unidadeDeNegocioService;
        private readonly ClienteService _clienteService;
        private readonly SolicitanteService _solicitanteService;
        public VouchersController(PersonalCarContext context, ClienteService clienteService, UnidadeDeNegocioService unidadeDeNegocioService, SolicitanteService solicitanteService)
        {
            _solicitanteService = solicitanteService;
            _clienteService = clienteService;
            _unidadeDeNegocioService = unidadeDeNegocioService;
            _context = context;
        }

        // GET: Vouchers
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Voucher.ToListAsync());
        }

        // GET: Vouchers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Voucher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // GET: Vouchers/Create
        public IActionResult Create()
        {
            var solicitantes = _solicitanteService.FindAll();
            var unidades = _unidadeDeNegocioService.FindAll();
            var clientes = _clienteService.FindAll();
            var viewModel = new VoucherViewModel { Clientes = clientes, UnidadeDeNegocios = unidades, Solicitantes = solicitantes };
            return View(viewModel);
        }

        // POST: Vouchers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,ControleDeTaxiamento,DataSolicitacao,DataInicial,DataFinal,ValorPedagio,ValorEstacionamento,KmInicial,KmFinal,Placa,ValorTotalDaViagem")] Voucher voucher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voucher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        
            return View(voucher);
        }

        // GET: Vouchers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Voucher.FindAsync(id);
            if (voucher == null)
            {
                return NotFound();
            }
            return View(voucher);
        }

        // POST: Vouchers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,ControleDeTaxiamento,DataSolicitacao,DataInicial,DataFinal,ValorPedagio,ValorEstacionamento,KmInicial,KmFinal,Placa,ValorTotalDaViagem")] Voucher voucher)
        {
            if (id != voucher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voucher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoucherExists(voucher.Id))
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
            return View(voucher);
        }

        // GET: Vouchers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voucher = await _context.Voucher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voucher == null)
            {
                return NotFound();
            }

            return View(voucher);
        }

        // POST: Vouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voucher = await _context.Voucher.FindAsync(id);
            _context.Voucher.Remove(voucher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoucherExists(int id)
        {
            return _context.Voucher.Any(e => e.Id == id);
        }
         
     

    }
}
