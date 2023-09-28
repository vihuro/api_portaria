namespace api_portaria.Dto.Entrada
{
    public class InsertEntradaDto
    {
        public string Transportadora { get;set; }
        public string Cliente { get; set; }
        public int PrimeroResponsavel { get; set; }
        public int SegundoResponsavel { get; set; }
    }
}
