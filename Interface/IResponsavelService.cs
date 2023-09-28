using api_portaria.Dto.Responsavel;

namespace api_portaria.Interface
{
    public interface IResponsavelService
    {
        Task<ReturnResponsavelDto> InsertResponsavel(InsertResponsavelDto dto);
        Task<List<ReturnResponsavelDto>> GetAll();
    }
}
