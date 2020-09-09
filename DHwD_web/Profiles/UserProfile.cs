using AutoMapper;
using DHwD.Model;
using DHwD_web.Dtos;

namespace DHwD_web.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
