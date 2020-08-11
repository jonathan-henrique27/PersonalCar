using System;
using System.Collections.Generic;

namespace PersonalCar.Models.Domains
{
    public class Motorista
    {
        //Atributos Basicos
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CNH { get; set; }
        public DateTime CnhVenc { get; set; }
        public DateTime Nascimento { get; set; }

        //Associações
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Construtores
        public Motorista()
        {
        }
        public Motorista(int id, string nome, int cNH, DateTime cnhVenc, DateTime nascimento)
        {
            Id = id;
            Nome = nome;
            CNH = cNH;
            CnhVenc = cnhVenc;
            Nascimento = nascimento;
        }
    }
}
