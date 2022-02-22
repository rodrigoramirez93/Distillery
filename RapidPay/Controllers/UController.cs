using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RapidPay.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("User/Authenticate")]
        public IActionResult Authenticate(UserDto userDto)
        {
            var result = _userService.Authenticate(userDto.UserName, userDto.Password);

            if (result == null)
                return BadRequest("Invalid credentials");

            return Ok(result);
        }
    }
}
