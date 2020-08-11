using System.Collections.Generic;

namespace PersonalCar.Models.Domains
{
    public class CentroDeCusto
    {
        //Atributos basicos
        public int Id { get; set; }
        public string Nome { get; set; }

        //Associações
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Construtores
        public CentroDeCusto()
        {
        }
        public CentroDeCusto(int id, int codigo, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
