using System;
using System.Collections.Generic;
using PersonalCar.Models.Enums;

namespace PersonalCar.Models.Domains
{
    public class Voucher
    {
        // Atributos basicos da Entidade
        public int Id { get; set; }
        public VoucherStatus Status { get; set; }
        public int ControleDeTaxiamento { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public double ValorPedagio { get; set; }
        public double ValorEstacionamento { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public string Placa { get; set; }
        public double ValorTotalDaViagem { get; set; }

        // Associações da Entidade Varios para UM
        public Cliente Cliente { get; set; }
        public UnidadeDeNegocio Unidade { get; set; }
        public CentroDeCusto CentroDeCusto { get; set; }
        public Motorista Motorista { get; set; }
        public Veiculo Veiculo { get; set; }

        // Associações da Entidade Um para Varios
        public ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();
        public ICollection<Viagem> Viagens { get; set; } = new List<Viagem>();
        public ICollection<HoraParada> HorasParado { get; set; } = new List<HoraParada>();

        //Metodos

        public void TotalHosrasParada(HoraParada parada)
        {
            HorasParado.Add(parada);
        }
        public void RemoveVoucher(HoraParada parada)
        {
            HorasParado.Remove(parada);
        }
        /*public double TotalHorasParado(DateTime initial, DateTime final)
        {
            return HorasParado.Where(hp => hp.Inicio >= initial && hp.Fim <= final).Count(List<HoraParada>);
        }*/

    }
}
