using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OutGetDotNet.Data;
using OutGetDotNet.Models;
using OutGetDotNet.Services.UserService;

namespace OutGetDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetMe"), Authorize]
        public ActionResult<string> GetMe()
        {
            return Ok(_userService.getMyName());
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (!response.Success)
            {
                return BadRequest(response.Data);
            }
            return Ok(response.Data);
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var response = await _userService.AddUser(user);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
        [HttpPut]
        public async Task<ActionResult<List<User>>> Updateuser(User user)
        {
            var response = await _userService.UpdateUser(user);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int Id)
        {
            var response = await _userService.DeleteUser(Id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Data);
        }
    }
}
