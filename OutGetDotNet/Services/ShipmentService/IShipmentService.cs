using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;

namespace OutGetDotNet.Services.ShipmentService
{
    public interface IShipmentService
    {
        Task<ServiceResponse<List<ShipmentDto>>> GetShipments();
        Task<ServiceResponse<ShipmentDto>> GetShipment(int Id);
        Task<ServiceResponse<ShipmentDto>> AddShipment(ShipmentDto shipmentDto);
        Task<ServiceResponse<ShipmentDto>> UpdateShipment(ShipmentDto shipment);
        Task<ServiceResponse<string>> DeleteShipment(int Id);
    }
}
