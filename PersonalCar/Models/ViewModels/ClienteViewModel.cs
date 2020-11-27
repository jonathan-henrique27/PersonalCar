
using PersonalCar.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCar.Models.ViewModels
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }
        public ICollection<UnidadeDeNegocio> UnidadeDeNegocios { get; set; }
        public ICollection<Cliente> Clientes { get; set; } 
    }
}
        