using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalCar.Models.Domains
{
    public class CentroDeCusto
    {
        //Atributos basicos
        public int Id { get; set; }
        [Display(Name = "Centro de Custo")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres")]
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
