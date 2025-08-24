using Aplication.Services.TaskManagement;
using Application.Services.TaskManagement;
using Application.Services.UserManagement;
using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Owner")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [HttpPost("GetBy")]
        public ResponesOutPut GetBy(UserSearchInput input)
        {
            var res = userService.GetBy(input);
            return new ResponesOutPut(res, ResponseStatus.Success, "Successfully");
        }


        [HttpPost("Insert")]
        public ResponesOutPut Insert(UserDto userDto)
        {
            try
            {
                var res = userService.Insert(userDto);
                return new ResponesOutPut(res, ResponseStatus.Success, "User added successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }

        [HttpPost("Update")]
        public ResponesOutPut Update(UserDto userDto)
        {
            try
            {
                var res = userService.Update(userDto);
                return new ResponesOutPut(res, ResponseStatus.Success, "User Updated successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }
        [HttpPost("Delete")]
        public ResponesOutPut Delete(int id)
        {
            try
            {
                var res = userService.Delete(id);
                return new ResponesOutPut(res, ResponseStatus.Success, "User Deleted successfully");
            }
            catch (Exception ex)
            {
                return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
            }
        }
        //[HttpPost("Login")]
        //public ResponesOutPut Login(LoginDto loginDto)
        //{
        //    try
        //    {
        //        var res = userService.LogIn(loginDto);
        //        return new ResponesOutPut(res, ResponseStatus.Success, "JWT successfully");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponesOutPut("null", ResponseStatus.Error, $"Error: {ex.Message}");
        //    }

        //}
    }
}
