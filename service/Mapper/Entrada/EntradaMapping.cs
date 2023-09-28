using api_portaria.Dto.Entrada;
using api_portaria.Model;
using AutoMapper;

namespace api_portaria.service.Mapper.Entrada
{
    public class EntradaMapping : Profile
    {
        public EntradaMapping()
        {
            CreateMap<InsertEntradaDto, EntradaModel>()
                .ForMember(x => x.Transportadora, map => map.MapFrom(src => src.Transportadora))
                .ForMember(x => x.Cliente, map => map.MapFrom(src => src.Cliente))
                .ForMember(x => x.DataHoraEntrada, map => map.MapFrom(src => DateTime.UtcNow))
                .ForMember(x => x.PrimeiroResponsavel, map => map.MapFrom(src => ValidadePrimeiroResponsavelModel(src.PrimeroResponsavel)))
                .ForMember(x => x.SegundoResponsavel, map => map.MapFrom(src => ValidadeSegundoResponsavelModel(src.SegundoResponsavel)));
            CreateMap<EntradaModel, ReturnEntradaDto>()
                .ForMember(x => x.NumeroEntrada, map => map.MapFrom(src => src.Id))
                .ForMember(x => x.Cliente, map => map.MapFrom(src => src.Cliente))
                .ForMember(x => x.Transportadora, map => map.MapFrom(src => src.Transportadora))
                .ForMember(x => x.DataHoraEntrada, map => map.MapFrom(src => ValidateDataHora(src.DataHoraEntrada)))
                .ForMember(x => x.DataHoraSaida, map => map.MapFrom(src => ValidateDataHora(src.DataHoraSaida)))
                .ForMember(x => x.TempoAtendimento, map => map.MapFrom(src => ValidateDataHora(src.TempoParaAtendimento)))
                .ForMember(x => x.PrimeiroResponsavel, map => map.MapFrom(src => ValidateResponsavelDto(src.PrimeiroResponsavel)))
                .ForMember(x => x.SegundoResponsavel, map => map.MapFrom(src => ValidateSegundoResponsavelDto(src.SegundoResponsavel)));
        }

        private static DateTime? ValidateDataHora(DateTime dataHora)
        {
            if (dataHora == DateTime.MinValue) return null;

            return dataHora;
        }

        private static string ValidateResponsavelDto(PrimeiroResponsavelEntradaModel primeiroResponsavel)
        {
            if(primeiroResponsavel == null) return null;

            return primeiroResponsavel.Responsavel.Nome;
        }
        private static string ValidateSegundoResponsavelDto(SegundoResponsavelEntradaModel primeiroResponsavel)
        {
            if (primeiroResponsavel == null) return null;

            return primeiroResponsavel.Responsavel.Nome;
        }

        private static PrimeiroResponsavelEntradaModel ValidadePrimeiroResponsavelModel(int responsavel)
        {
            if (responsavel == 0) return null;

            return new PrimeiroResponsavelEntradaModel
            {
                ResponsavelId = responsavel
            };
        }
        private static SegundoResponsavelEntradaModel ValidadeSegundoResponsavelModel(int responsavel)
        {
            if (responsavel == 0) return null;

            return new SegundoResponsavelEntradaModel
            {
                ResponsavelId = responsavel
            };
        }
    }
}
