using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalCar.Models.Domains;

namespace PersonalCar.Data
{
    public class PersonalCarContext : DbContext
    {
        public PersonalCarContext (DbContextOptions<PersonalCarContext> options)
            : base(options)
        {
        }
        public DbSet<CentroDeCusto> CentroDeCusto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<HoraParada> HoraParada { get; set; }
        public DbSet<Motorista> Motorista { get; set; }
        public DbSet<Passageiro> Passageiro { get; set; }
        public DbSet<Viagem> Produto { get; set; }


        public DbSet<Solicitante> Solicitante { get; set; }
        public DbSet<UnidadeDeNegocio> UnidadeDeNegocio { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Voucher> Voucher { get; set; }
    }
}
