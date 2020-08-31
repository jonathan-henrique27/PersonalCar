using System;
using PersonalCar.Data;
using PersonalCar.Models.Domains;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalCar.Models.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace PersonalCar.Models.Services
{
    public class ClienteService
    {
        private readonly PersonalCarContext _context;

        public ClienteService(PersonalCarContext context)
        {
           _context = context;
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }
    }
}