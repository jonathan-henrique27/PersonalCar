using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCar.Models.Domains
{
    public class Veiculo
    {
        // Atributos basicos
        public int Id { get; set; }
        public string Placa { get; set; }

        [Display(Name = "Modelo do Veiculo")]
        
        public string Modelo { get; set; }
        public string Ano { get; set; }

        //Associações
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Construtores
        public Veiculo()
        {
        }

        public Veiculo(int id, string placa, string modelo, string ano)
        {
            Id = id;
            Placa = placa;
            Modelo = modelo;
            Ano = ano;
        }
    }
}
