using AutoMapper;

namespace TakeBookService.Models.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<ClientBook, ClientBookDto>().ReverseMap();
    }
}
