using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<Product,ExportProductDto>()
                .ForMember(d => d.Buyer, 
                    opt => opt.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));
        }
    }
}
