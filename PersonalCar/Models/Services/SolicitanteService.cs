using System;
using System.Collections.Generic;
using System.Linq;
using PersonalCar.Data;
using System.Threading.Tasks;
using PersonalCar.Models.Domains;
using PersonalCar.Models.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace PersonalCar.Models.Services
{
    public class SolicitanteService
    {
        private readonly PersonalCarContext _context;

        public SolicitanteService(PersonalCarContext context)
        {
            _context = context;
        }

        public List<Solicitante> FindAll()
        {
            return _context.Solicitante.ToList();
        }
        public void Insert(Solicitante obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
        
        public Solicitante FindById(int id)
        {
            return _context.Solicitante.Include(obj => obj.UnidadeDeNegocio).FirstOrDefault(obj => obj.Id == id);
        }
        
        public void Remove(int id)
        {
            var obj = _context.Solicitante.Find(id);
            _context.Solicitante.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Solicitante obj)
        {
            if (!_context.Solicitante.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
