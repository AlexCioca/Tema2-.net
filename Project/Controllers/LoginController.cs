using Core.Services;
using DataLayer;
using DataLayer.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Project.Controllers
{

    [ApiController]
    [Route("api/login")]
    public class LoginController: ControllerBase
    {
        private AuthService authService;
        public UserService userService;
        public CurrentUserService currentUserService;

        public LoginController(AuthService authService,UserService userService, CurrentUserService currentUserService)
        {
            this.authService = authService;
            this.userService = userService;
            this.currentUserService = currentUserService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]UserDto userDto)
        {
            var user = userService.GetUser(userDto.Name);


            if (user != null)
            {

                user.Token = authService.GenerateToken(user);
                userService.UpdateUser(user);
                currentUserService.CurrentUser = user.Name;

                return Ok(user.Token);

            }
            return BadRequest();

        }
        [Authorize("ADMIN")]
        [HttpGet("get-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = currentUserService.CurrentUser;
            return Ok(user);
        }
    }
}
