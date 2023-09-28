namespace api_portaria.Dto.Entrada
{
    public class ReturnEntradaDto
    {
        public int NumeroEntrada { get; set; }
        public string Transportadora { get; set; }
        public string Cliente { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public DateTime TempoAtendimento { get; set; }
        public string PrimeiroResponsavel { get; set; }
        public string SegundoResponsavel { get; set; }
    }
}
