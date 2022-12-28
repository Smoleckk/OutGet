using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutGetDotNet.ModelsDto;
using OutGetDotNet.Services.LockerService;

namespace OutGetDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LockerController : ControllerBase
    {
        private readonly ILockerService _lockerService;

        public LockerController(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LockerDto>>> GetLockers()
        {
            var response = await _lockerService.GetLockers();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data.ToArray());
        }
        [HttpPost]
        public async Task<ActionResult<LockerDto>> AddShipment(LockerDto lockerDto)
        {
            var response = await _lockerService.AddLocker(lockerDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response.Data);
        }
    }
}
