using ProductShop.DTOs.Export;

namespace ProductShop
{
    using AutoMapper;
    using DTOs.Import;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto,Product>();
            this.CreateMap<Product, ExportProductInRangeDto>()
                .ForMember(d => d.ProductName,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.ProductPrice,
                    opt => opt.MapFrom(d => d.Price))
                .ForMember(d => d.SellerName,
                    opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<ImportCategoryDto, Category>();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
