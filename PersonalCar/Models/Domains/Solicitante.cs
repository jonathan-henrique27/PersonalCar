using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCar.Models.Domains
{
    public class Solicitante
    {
        //Atributos Basico
        public int Id { get; set; }

        [Display(Name = "Solicitante")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Telefone Comercial")]
        [DataType(DataType.PhoneNumber)]
        public string Telecom { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Cargo")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "{0} deve ter {1} caracteres")]
        public string Cargo { get; set; }

        //Associações
        public UnidadeDeNegocio UnidadeDeNegocio { get; set; }
        [Display(Name = "Unidade")]
        public int UnidadeDeNegocioId { get; set; }

        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();

        //Construtores
        public Solicitante()
        {
        }

        public Solicitante(int id, string nome, string telecom, string celular, string email, string cargo, UnidadeDeNegocio unidadeDeNegocio, int unidadeDeNegocioId)
        {
            Id = id;
            Nome = nome;
            Telecom = telecom;
            Celular = celular;
            Email = email;
            Cargo = cargo;
            UnidadeDeNegocio = unidadeDeNegocio;
            UnidadeDeNegocioId = unidadeDeNegocioId;
        }
    }
}
