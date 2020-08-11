using PersonalCar.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCar.Models.ViewModels
{
    public class UnidadeDeNegocioViewModel
    {
        public UnidadeDeNegocio UnidadeDeNegocio { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
