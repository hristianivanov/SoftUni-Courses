using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportCarDto, Car>();
            this.CreateMap<int, PartCar>()
                .ForMember(d => d.PartId, opt => opt.MapFrom(src => src));
        }
    }
}
