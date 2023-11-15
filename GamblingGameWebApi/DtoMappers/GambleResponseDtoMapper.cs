using AutoMapper;
using GamblingGameWebApi.Entities.Domains.GambleRequests;
using GamblingGameWebApi.Entities.Domains.GambleRequests.Dtos;

namespace GamblingGameWebApi.DtoMappers;

public class GambleResponseDtoMapper : Profile
{
    public GambleResponseDtoMapper()
    {
        CreateMap<GambleResponseDto, GambleResponse>().ReverseMap();
    }
}
