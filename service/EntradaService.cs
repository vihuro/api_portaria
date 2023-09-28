using api_portaria.ContextBase;
using api_portaria.Dto.Entrada;
using api_portaria.Interface;
using api_portaria.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_portaria.service
{
    public class EntradaService : IEntradaService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public EntradaService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnEntradaDto> InsertEntrada(InsertEntradaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Transportadora) ||
                string.IsNullOrWhiteSpace(dto.Cliente) ||
                string.IsNullOrEmpty(dto.PrimeroResponsavel.ToString()))
                throw new Exception("Campo(s) obrigatório(s) vazio(s)!") { HResult = 400 };
            var obj = _mapper.Map<EntradaModel>(dto);

            _context.Entrada.Add(obj);
            await _context.SaveChangesAsync();

            return await GetById(obj.Id);
        }
        public async Task<List<ReturnEntradaDto>> GetAll()
        {
            var list = await _context.Entrada
                .Include(r => r.PrimeiroResponsavel)
                    .ThenInclude(r => r.Responsavel)
                .Include(r => r.SegundoResponsavel)
                    .ThenInclude(r => r.Responsavel)
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();

            if (list[1].DataHoraSaida == DateTime.MinValue) Console.Write("é meor");

            var dto = _mapper.Map<List<ReturnEntradaDto>>(list);

            return dto;

        }

        public async Task<ReturnEntradaDto> GetById(int id)
        {
            var obj = await _context.Entrada
                .Include(r => r.PrimeiroResponsavel)
                    .ThenInclude(r => r.Responsavel)
                .Include(r => r.SegundoResponsavel)
                    .ThenInclude(r => r.Responsavel)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<ReturnEntradaDto>(obj);

        }
    }
}
