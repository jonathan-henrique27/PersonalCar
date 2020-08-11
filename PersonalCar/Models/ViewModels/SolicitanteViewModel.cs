using PersonalCar.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCar.Models.ViewModels
{
    public class SolicitanteViewModel
    {
        public Solicitante Solicitante { get; set; }
        public ICollection<UnidadeDeNegocio> UnidadeDeNegocios { get; set; }
    }
}
