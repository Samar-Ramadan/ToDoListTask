using Application.Models.UserManagement;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService : IRepository<UserEntity>
    {
        public Task<GeneralOutPut<UserModel>> GetBy(UserSearchInput input,CancellationToken cancellationToken);
        public Task<bool> Insert(UserModel UserDto, CancellationToken cancellationToken);
        //public Task<bool> Update(UserModel UserDto, CancellationToken cancellationToken);
        //public Task<bool> Delete(int Id, CancellationToken cancellationToken);
        public Task<string> LogIn(LoginModel loginDto, CancellationToken cancellationToken);
    }
}
