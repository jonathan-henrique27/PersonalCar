using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace PersonalCar.Models.Domains
{
    public class Cliente
    {
        //Atributos basicos
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Cliente")]
        public string NomeFantasia { get; set; }

        // Associações
        public ICollection<UnidadeDeNegocio> UnidadeDeNegocios { get; set; } = new List<UnidadeDeNegocio>();
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Contrutores
        public Cliente()
        {
        }
        public Cliente(int id, string nome)
        {
            Id = id;
            NomeFantasia = nome;
        }
        public void AddUnidade(UnidadeDeNegocio unidade)
        {
            UnidadeDeNegocios.Add(unidade);
        }
        public void RemoveUnidade(UnidadeDeNegocio unidade)
        {
            UnidadeDeNegocios.Remove(unidade);
        }
        public void AddVoucher(Voucher voucher)
        {
            Vouchers.Add(voucher);
        }
        public void RemoveVoucher(Voucher voucher)
        {
            Vouchers.Remove(voucher);
        }
        public double TotalVouchers(DateTime initial, DateTime final)
        {
            return Vouchers.Where(vv => vv.DataInicial >= initial && vv.DataFinal <= final).Sum(vv => vv.ValorTotalDaViagem);
        }

    }
}
