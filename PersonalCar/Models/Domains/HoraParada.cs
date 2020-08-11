using System;

namespace PersonalCar.Models.Domains
{
    public class HoraParada
    {
        // Atributos Basicos da Entidade
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        // Associações da Entidade Varios para UM
        public Voucher Voucher { get; set; }
    }
}
