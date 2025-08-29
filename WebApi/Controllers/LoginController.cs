using Application.Interfaces;
using Application.Models.UserManagement;
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
        public ResponesOutPut Login(LoginModel loginDto, CancellationToken cancellationToken)
        {
            try
            {
                var res = userService.LogIn(loginDto, cancellationToken);
                return  ResponesOutPut.Create(res, ResponseStatus.Success, "JWT successfully");
            }
            catch (Exception ex)
            {
                return  ResponesOutPut.Create("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }

        }

    }
}
