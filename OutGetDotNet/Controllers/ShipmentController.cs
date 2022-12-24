using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutGetDotNet.Models;
using OutGetDotNet.ModelsDto;
using OutGetDotNet.Services.ShipmentService;

namespace OutGetDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public ShipmentController(IShipmentService shipmentService, IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShipmentDto>>> GetShipments()
        {
            var response = await _shipmentService.GetShipments();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data.ToArray());
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<ShipmentDto>> GetShipment(int Id)
        {
            var response = await _shipmentService.GetShipment(Id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddShipment(AddShipmentDto shipmentDto)
        {
            var response = await _shipmentService.AddShipment(shipmentDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data);
        }
        [HttpPut]
        public async Task<ActionResult<string>> UpdateShipment(ShipmentDto shipmentDto)
        {
            var response = await _shipmentService.UpdateShipment(shipmentDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data);
        }
    }
}
