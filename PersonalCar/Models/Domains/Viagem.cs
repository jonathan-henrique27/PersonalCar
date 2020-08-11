namespace PersonalCar.Models.Domains
{
    public class Viagem
    {
        // Atributos basicos
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double TotalKM { get; set; }
        public double ValorPorKm { get; set; }
        public double ValorTotal { get; set; }

        // Associações
        public Voucher Voucher { get; set; }

        // Construtores
        public Viagem()
        {
        }
        public Viagem(int id, string origem, string destino, double totalKM, double valorPorKm, double valorTotal, Voucher voucher)
        {
            Id = id;
            Origem = origem;
            Destino = destino;
            TotalKM = totalKM;
            ValorPorKm = valorPorKm;
            ValorTotal = valorTotal;
            Voucher = voucher;
        }
    }
}
