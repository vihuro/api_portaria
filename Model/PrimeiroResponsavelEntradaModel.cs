using System.ComponentModel.DataAnnotations.Schema;

namespace api_portaria.Model
{
    [Table("tab_PrimeiroResponsavelEntrada")]
    public class PrimeiroResponsavelEntradaModel
    {
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public int ResponsavelId { get; set; }
        public EntradaModel Entrada { get; set; }
        public ResponsavelModel Responsavel { get; set; }
    }
}
