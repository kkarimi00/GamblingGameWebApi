using AutoMapper;
using GamblingGameWebApi.Entities.Domains.GambleRequests;

namespace GamblingGameWebApi.DtoMappers
{
    public class GambleRequestDtoMapper : Profile
    {
        public GambleRequestDtoMapper()
        {
            CreateMap<GambleRequestDto, GambleRequest>().ReverseMap();
        }
    }
}
