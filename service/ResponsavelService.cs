using api_portaria.ContextBase;
using api_portaria.Dto.Responsavel;
using api_portaria.Interface;
using api_portaria.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_portaria.service
{
    public class ResponsavelService : IResponsavelService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ResponsavelService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReturnResponsavelDto> InsertResponsavel(InsertResponsavelDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nome))
                throw new Exception("Campo obrigatório vazio!") { HResult = 404 };

            var obj = new ResponsavelModel
            {
                Nome = dto.Nome,
            };
            _context.Responsavel.Add(obj);
            await _context.SaveChangesAsync();

            var inMapper = new ReturnResponsavelDto
            {
                Id = obj.Id,
                Nome = obj.Nome
            };

            return inMapper;
        }
        public async Task<List<ReturnResponsavelDto>> GetAll()
        {
            var list = await _context.Responsavel.ToListAsync();

            var dto = new List<ReturnResponsavelDto>();
            foreach (var item in list)
            {
                dto.Add(new ReturnResponsavelDto
                {
                    Id = item.Id,
                    Nome = item.Nome
                });
            }
            return dto;
        }
    }
}
