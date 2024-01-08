using AuthService.Api.Models;
using AuthService.Persistence.Models;
using AutoMapper;

namespace AuthService.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, User>();
        CreateMap<User, LoginResponseDTO>();
    }
}
