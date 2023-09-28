using System.ComponentModel.DataAnnotations.Schema;

namespace api_portaria.Model
{
    [Table("tab_entrada")]
    public class EntradaModel
    {
        public int Id { get; set; }
        public string Transportadora { get; set; }
        public string Cliente { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public DateTime TempoParaAtendimento { get; set; }
        public PrimeiroResponsavelEntradaModel PrimeiroResponsavel { get; set; }
        public SegundoResponsavelEntradaModel SegundoResponsavel { get; set; }
    }
}
