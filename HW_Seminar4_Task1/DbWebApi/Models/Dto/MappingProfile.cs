using AutoMapper;

namespace DbWebApi.Models.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<ProductGroupModel, ProductGroup>().ReverseMap();
        }
    }
}
