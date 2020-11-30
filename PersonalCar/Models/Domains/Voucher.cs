using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalCar.Models.Enums;
using PersonalCar.Models.ViewModels;

namespace PersonalCar.Models.Domains
{
    public class Voucher
    {
        // Atributos basicos da Entidade
        public int Id { get; set; }

        public VoucherStatus Status { get; set; }

        [Display(Name = "Taxiamento Nº")]
        public string ControleDeTaxiamento { get; set; }

        [Display(Name = "Data Solicitação")]
        [DataType(DataType.DateTime)]
       
        public DateTime DataSolicitacao { get; set; }

        [Display(Name = "Inicio")]
        public DateTime DataInicial { get; set; }

        [Display(Name = "Final")]
        public DateTime DataFinal { get; set; }

        [Display(Name = "Valor Pedagio")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorPedagio { get; set; }

        [Display(Name = "Valor Estacionamento")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorEstacionamento { get; set; }

        [Display(Name = "Km Inicial")]
        public double KmInicial { get; set; }

        [Display(Name = "Km Final")]
        public double KmFinal { get; set; }

        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Display(Name = "Valor Total da Viagem")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorTotalDaViagem { get; set; }

        // Associações da Entidade Varios para UM
        public Cliente Cliente { get; set; }

        public UnidadeDeNegocio UnidadeDeNegocio { get; set; }

        public Solicitante Solicitante { get; set; }

        public CentroDeCusto CentroDeCusto { get; set; }

        public Motorista Motorista { get; set; }

        public Veiculo Veiculo { get; set; }

        // Associações da Entidade Um para Varios
        public ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();
        
        public ICollection<Viagem> Viagens { get; set; } = new List<Viagem>();
        public ICollection<HoraParada> HorasParado { get; set; } = new List<HoraParada>();

        //Metodos

        public void TotalHorasParada(HoraParada parada)
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
