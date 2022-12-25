using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Data;
using OutGetDotNet.Migrations;
using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;
using System.Reflection;
using Shipment = OutGetDotNet.Models.Shipment;

namespace OutGetDotNet.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ShipmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ShipmentDto>>> GetShipments()
        {
            var response = new ServiceResponse<List<ShipmentDto>>();
            List<ShipmentDto> sdList = new();
            var r = await _context.Shipments.ToListAsync();
            foreach (var s in r)
            {
                ShipmentDto sd = new ShipmentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    State = s.State,

                };
                sdList.Add(sd);
            }
            response.Success = true;
            response.Message = "Successfully get shipment";
            response.Data = sdList;

            return response;
        }
        //_context.Shipments.Select(s => _mapper.Map<GetShipmentDto>(s))
        public async Task<ServiceResponse<ShipmentDto>> GetShipment(int Id)
        {
            var response = new ServiceResponse<ShipmentDto>();

            var s = await _context.Shipments.FirstOrDefaultAsync(i => i.Id == Id);
            if (s == null)
            {
                response.Success = false;
                response.Message = "Shipment not found";
                return response;

            }
            ShipmentDto sd = new ShipmentDto
            {
                Id = s.Id,
                Name = s.Name,
                State = s.State,
            };
            response.Message = "Shipment successfully get";
            response.Data = sd;
            return response;
        }

        public async Task<ServiceResponse<ShipmentDto>> AddShipment(ShipmentDto shipmentDto)
        {
            var response = new ServiceResponse<ShipmentDto>();
            var sender = await _context.Users.FindAsync(2);
            var receiver = await _context.Users.FindAsync(2);

            var newShipment = new Shipment
            {
                Name = shipmentDto.Name,
                State = shipmentDto.State,
                Sender = sender,
                Receiver = receiver
            };
            _context.Shipments.Add(newShipment);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Successfully add shipment";
            response.Data = shipmentDto;
            return response;
        }
        //public async Task<ServiceResponse<string>> AddShipment(AddShipmentDto shipmentDto)
        //{
        //    var response = new ServiceResponse<string>();
        //    var sender = await _context.Users.FindAsync(shipmentDto.SenderId);
        //    var receiver = await _context.Users.FindAsync(shipmentDto.ReceiverId);

        //    var newShipment = new Shipment
        //    {
        //        Name = shipmentDto.Name,
        //        State = shipmentDto.State,
        //        Sender = sender,
        //        Receiver = receiver
        //    };
        //    _context.Shipments.Add(newShipment);
        //    await _context.SaveChangesAsync();

        //    response.Success = true;
        //    response.Message = "Successfully add shipment";
        //    response.Data = "Successfully add shipment";
        //    return response;
        //}
        public async Task<ServiceResponse<string>> DeleteShipment(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<ShipmentDto>> UpdateShipment(ShipmentDto shipment)
        {
            var response = new ServiceResponse<ShipmentDto>();

            var ship = await _context.Shipments.FirstOrDefaultAsync(i => i.Id == shipment.Id);
            if (ship == null)
            {
                response.Success = false;
                response.Message = "Shipment not found";
                return response;

            }

            ship.State = shipment.State;
            _context.Shipments.Update(ship);
            await _context.SaveChangesAsync();

            response.Data = shipment;
            return response;
        }
    }
}
