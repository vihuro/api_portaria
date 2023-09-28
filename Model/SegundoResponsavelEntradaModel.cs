using System.ComponentModel.DataAnnotations.Schema;

namespace api_portaria.Model
{
    [Table("tab_SegundoResponsavelEntrada")]
    public class SegundoResponsavelEntradaModel
    {
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public int ResponsavelId { get; set; }
        public EntradaModel Entrada { get; set; }
        public ResponsavelModel Responsavel { get; set; }
    }
}
