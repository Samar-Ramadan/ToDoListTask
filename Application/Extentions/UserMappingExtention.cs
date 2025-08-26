
using Application.Models.UserManagement;
using Domain.Entities;

namespace Application.Extentions
{
    public static class UserMappingExtention
    {
        public static UserModel ToModel(this UserEntity user)
        {
            if (user == null) return null;

            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
            };
        }

        public static List<UserModel> ToModelList(this List<UserEntity> users)
        {
            return users.Select(t => t.ToModel()).ToList();
        }

        public static UserEntity ToEntity(this UserModel user)
        {
            if (user == null) return null;

            return new UserEntity
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
            };
        }
    }
}
