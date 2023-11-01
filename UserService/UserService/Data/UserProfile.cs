using AutoMapper;
using UserService.Data.DTOs;
using UserService.Data.Models;

namespace UserService.Data
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SignInUserDTO, User>();
        }
    }
}
