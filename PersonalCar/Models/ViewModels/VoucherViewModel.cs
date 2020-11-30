using DocumentFormat.OpenXml.Wordprocessing;
using PersonalCar.Models.Domains;
using PersonalCar.Models.Enums;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCar.Models.ViewModels
{
    public class VoucherViewModel
    {
        public Voucher Voucher {get; set; }
        public virtual ICollection<UnidadeDeNegocio> UnidadeDeNegocios { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Solicitante> Solicitantes { get; set; }
         
        public virtual ICollection<Passageiro> Passageiros { get; set; }

        
      
    }
}
