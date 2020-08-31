using System.Collections.Generic;
using System.Linq;
using PersonalCar.Models.Domains;
using PersonalCar.Models.Services.Exceptions;
using PersonalCar.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace PersonalCar.Models.Services
{
    public class UnidadeDeNegocioService
    {
        
        private readonly PersonalCarContext _context;

        public UnidadeDeNegocioService(PersonalCarContext context)
        {
            _context = context;
        }
        public List<UnidadeDeNegocio> FindAll()
        {
            return _context.UnidadeDeNegocio.ToList();
        }
    
        public void Insert(UnidadeDeNegocio obj)
        {
            _context.Add(obj);
            _context.SaveChanges();

        }
        public UnidadeDeNegocio FindById(int id)
        {
            return _context.UnidadeDeNegocio.Include(obj => obj.Cliente).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.UnidadeDeNegocio.Find(id);
            _context.UnidadeDeNegocio.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(UnidadeDeNegocio obj)
        {
            if (!_context.UnidadeDeNegocio.Any(x => x.Id == obj.Id))
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
