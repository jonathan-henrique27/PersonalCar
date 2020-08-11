using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCar.Models.Domains
{
    public class UnidadeDeNegocio
    {
        //Atributos Basicos
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome da Unidade")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "Razão Social é obrigatória")]
        [StringLength(60, MinimumLength = 15, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string RazaoSocial { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "{0} invalido")]
        public string Cnpj { get; set; }

        [Display(Name = "Cep")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "CEP é obrigatório")]
        [StringLength(9, MinimumLength = 8, ErrorMessage = "{0} invalido")]
        public string Cep { get; set; }

        [Display(Name = "Número")]
        [DataType(DataType.Text)]
        [StringLength(6)]
        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero { get; set; }


        [Display(Name = "Endereço")]
        [DataType(DataType.Text)]
        [StringLength(60)]
        public string Endereco { get; set; }

        [Display(Name = "Bairro")]
        [DataType(DataType.Text)]
        [StringLength(40)]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(40)]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2)]
        public string Estado { get; set; }

        [Display(Name = "Codigo IBGE")]
        public string Ibge { get; set; }

        // Associações
        public Cliente Cliente { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public ICollection<CentroDeCusto> CentroDeCustos { get; set; } = new List<CentroDeCusto>();
        public ICollection<Solicitante> Solicitantes { get; set; } = new List<Solicitante>();
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Construtores
        public UnidadeDeNegocio()
        {
        }
        public UnidadeDeNegocio(int id, string nomeFantasia, string razaoSocial, string cnpj, Cliente cliente, int clienteId)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            Cliente = cliente;
            ClienteId = clienteId;
        }

        public void AddSolicitante(Solicitante sl)
        {
            Solicitantes.Add(sl);
        }
        public void RemoveSolicitante(Solicitante sl)
        {
            Solicitantes.Remove(sl);
        }
    }
}
