
using Application;
using Application.Extentions;
using Application.Interfaces;
using Application.Models.UserManagement;
using Domain.Entities;
using Domain.Enum;
using Infrastructures.Data;
using System.Threading;

namespace Infrastructures.Implementation.UserManagement
{
    public class UserService : Repository<UserEntity>, IUserService
    {
        private readonly IJwtService _jwtService;

        public UserService(AppDbContext context, IJwtService jwtService) : base(context)
        {
            _jwtService = jwtService;
        }

        public async Task<GeneralOutPut<UserModel>> GetBy(UserSearchInput input, CancellationToken cancellationToken)
        {
            var listuserEntities =  base.GetBy(x => input.Search == null ? 1 == 1 : x.Username.Contains(input.Search), cancellationToken).Result.ToList();
            var listuserModel = listuserEntities.ToModelList();
            return Pagination<UserModel>.PaginationList(listuserModel.AsQueryable(), input);
        }

        public async Task<bool> Insert(UserModel UserDto, CancellationToken cancellationToken)
        {
            return await base.Add(UserDto.ToEntity(), cancellationToken);
        }

        //public string Update(UserModel UserDto)
        //{
        //    var entity = GetById(UserDto.Id);
        //    var map = _mapper.Map(UserDto, entity);
        //    var res = Update(map);
        //    return "true";
        //}
        //public string Delete(int id)
        //{
        //    var entity = GetById(id);
        //    Delete(entity);
        //    return "true";
        //}
        public async Task<string> LogIn(LoginModel loginDto, CancellationToken cancellationToken)
        {
            var res = base.GetBy(x => x.Username == loginDto.Username && x.Password == loginDto.Password, cancellationToken).Result.FirstOrDefault();
            if (res != null)
            {
                var token = _jwtService.GenerateToken(
                userId: res.Id,
                username: res.Username,
                roles: new List<string> { res.Role == UserRole.Owner ? "Owner" : "Guest" });

                return token;
            }
            return "false";
        }


    }
}
