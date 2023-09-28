using api_portaria.Dto.Entrada;

namespace api_portaria.Interface
{
    public interface IEntradaService
    {
        Task<ReturnEntradaDto> InsertEntrada(InsertEntradaDto dto);
        Task<ReturnEntradaDto> GetById(int id);
        Task<List<ReturnEntradaDto>> GetAll();
    }
}
