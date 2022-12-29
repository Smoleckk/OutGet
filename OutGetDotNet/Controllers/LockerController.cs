﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OutGetDotNet.ModelsDto;
using OutGetDotNet.Services.LockerService;
using System.Data;

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
        [Authorize(Roles = "Admin,Demo,User")]
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
        [Authorize(Roles = "Admin")]
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
