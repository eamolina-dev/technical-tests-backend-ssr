using AutoMapper;
using technical_tests_backend_ssr.Models;
using technical_tests_backend_ssr.Dtos;

namespace technical_tests_backend_ssr.MappingServices
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<SaveProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
