using Core.IGenericRepository;
using Core.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserManagement
{
    public interface IUserService:IRepository<Users>
    {
        public GeneralOutPut<UserDto> GetBy(UserSearchInput input);
        public string Insert(UserDto UserDto);
        public string Update(UserDto UserDto);
        public string Delete(int Id);
        public string LogIn(LoginDto loginDto);

    }
}
