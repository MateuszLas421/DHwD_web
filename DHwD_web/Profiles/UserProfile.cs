using AutoMapper;
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
            CreateMap<Points, PointsReadDto>();
            CreateMap<PointsCreateDto, Points>();
            CreateMap<ActivePlace, ActivePlacesReadDto>();
            CreateMap<ActivePlacesCreateDto, ActivePlace>();
            CreateMap<Status, StatusReadDto>();
            CreateMap<StatusCreateDto, Status>();
            CreateMap<Place, PlaceReadDto>();
        }
    }
}
