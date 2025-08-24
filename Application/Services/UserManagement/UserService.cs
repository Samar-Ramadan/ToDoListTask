using Aplication.Services.TaskManagement;
using Application.Services.JwtService;
using Application.Services.TaskManagement;
using AutoMapper;
using Core.Enum;
using Core.Models;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserManagement
{
    public class UserService : Repository<Users>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _config;
        private readonly IJwtService _jwtService;
        //
        public UserService(AppDbContext context,IMapper mapper, IJwtService jwtService) : base(context)
        {
            _jwtService = jwtService;
            _mapper = mapper;
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UserDto>().ReverseMap();
                cfg.CreateMap<Users, LoginDto>().ReverseMap();
            });
            //_config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, LoginDto>().ReverseMap(); });
            _mapper = _config.CreateMapper();
        }

        public GeneralOutPut<UserDto> GetBy(UserSearchInput input)
        {
            IQueryable<UserDto> res = _mapper.ProjectTo<UserDto>(base.GetBy(x => input.Search == null ? 1==1 :  x.Username.Contains(input.Search)));
            return Pagination<UserDto>.PaginationList(res.AsQueryable(), input);
        }

        public string Insert(UserDto UserDto)
        {
            var map = _mapper.Map<Users>(UserDto);
            var res= base.Add(map);
            return "true";
        }

        public string Update(UserDto UserDto)
        {
            var entity = base.GetById(UserDto.Id);
            var map = _mapper.Map<UserDto,Users>(UserDto, entity);
            var res = base.Update(map);
            return "true";
        }
        public string Delete(int id)
        {
            var entity = base.GetById(id);
            base.Delete(entity);
            return "true";
        }
        public string LogIn(LoginDto loginDto)
        {
            var res = base.GetBy(x =>  x.Username == loginDto.Username && x.Password == loginDto.Password).FirstOrDefault();
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
