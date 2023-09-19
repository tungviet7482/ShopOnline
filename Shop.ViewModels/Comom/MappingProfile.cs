using AutoMapper;
using Shop.Data.Entities;
using Shop.ViewModels.Categorys;
using Shop.ViewModels.Products;

namespace Shop.ViewModels.Comom
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductCreateRequest, Product>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
