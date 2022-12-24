using AutoMapper;
using OutGetDotNet.Migrations;
using OutGetDotNet.ModelsDto;

namespace OutGetDotNet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shipment, ShipmentDto>();
            CreateMap<ShipmentDto, Shipment>();

        }
    }
}
