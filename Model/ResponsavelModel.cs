using System.ComponentModel.DataAnnotations.Schema;

namespace api_portaria.Model
{
    [Table("tab_responsavel")]
    public class ResponsavelModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
