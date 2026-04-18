using AutoMapper;
using NorthWindCatalog.Services.DTOs;
using NorthWindCatalog.Services.Models;

namespace NorthWindCatalog.Services.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>()
    .ForMember(dest => dest.ImageUrl,
        opt => opt.MapFrom(src => "/images/" + src.CategoryId + ".jpeg"));

            CreateMap<Product, ProductDto>();
        }
    }
}
