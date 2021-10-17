using AutoMapper;
using SampleMvvmAppWithDI.DAL;

namespace SampleMvvmAppWithDI.DTOs.MapperProfiles
{
    public class DtoProfiles : Profile
    {
        public DtoProfiles()
        {
            CreateMap<SampleEntity, SampleEntityDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name));
        }
    }
}
