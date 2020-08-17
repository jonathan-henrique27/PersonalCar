using System.Collections.Generic;

namespace PersonalCar.Models.Domains
{
    public class Passageiro
    {
        //Atributos basicos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
  
        //Associações
        public Voucher Voucher { get; set; }

        //Contrutores
        public Passageiro()
        {
        }
        public Passageiro(int id, string nome, string celular, Voucher voucher)
        {
            Id = id;
            Nome = nome;
            Celular = celular;
            Voucher = voucher;
        }
    }
}
