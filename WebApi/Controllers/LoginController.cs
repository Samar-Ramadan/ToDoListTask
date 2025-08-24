using Application.Services.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController:ControllerBase
    {

        private readonly IUserService userService;
        public LoginController(IUserService _userService)
        {
            this.userService = _userService;
        }


        [HttpPost("Login")]
        public ResponesOutPut Login(LoginDto loginDto)
        {
            try
            {
                var res = userService.LogIn(loginDto);
                return new ResponesOutPut(res, ResponseStatus.Success, "JWT successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }

        }

    }
}
