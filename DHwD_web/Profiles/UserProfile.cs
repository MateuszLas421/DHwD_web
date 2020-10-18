using AutoMapper;
using DHwD.Model;
using DHwD_web.Dtos;
using DHwD_web.Models;

namespace DHwD_web.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            //Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<TeamCreateDto, Team>();
            CreateMap<Team, TeamReadDto>();
            CreateMap<GamesCreateDto, Games>();
            CreateMap<Games, GamesReadDto> ();
            CreateMap<TeamMembers, TeamMembersReadDto>();
            CreateMap<TeamMembersCreateDto, TeamMembers>();
        }
    }
}
