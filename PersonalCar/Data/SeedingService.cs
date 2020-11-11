using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using PersonalCar.Models;
using PersonalCar.Models.Domains;

namespace PersonalCar.Data
{
    public class SeedingService
    {
        private PersonalCarContext _context;

        public SeedingService(PersonalCarContext context)
        {
            _context = context;
        }


        public void Seed()
        {
            if (_context.Cliente.Any() ||
                _context.UnidadeDeNegocio.Any() ||
                _context.Solicitante.Any() || 
                _context.Passageiro.Any() || 
                _context.Voucher.Any())
            {
                return;
            }

           
            Cliente c1 = new Cliente(1, "Jung Hoseok");

            UnidadeDeNegocio u1 = new UnidadeDeNegocio(1, "Park Jimin", "Min Yoongi", "78.706.845/0001-94", c1, c1.Id);

            Solicitante s1 = new Solicitante(1, "Kim Namjoon", "3255633255", "123456789", "namjoonie@gmail.com", "Idol", u1, u1.Id);

            Voucher v1 = new Voucher();

            Passageiro p1 = new Passageiro(1, "Hyunjin", "777-666901", v1);

            _context.Cliente.AddRange(c1);
            _context.UnidadeDeNegocio.AddRange(u1);
            _context.Solicitante.AddRange(s1);
            _context.Passageiro.AddRange(p1);

            _context.SaveChanges();
        }
    }
}
