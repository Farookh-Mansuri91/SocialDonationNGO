using AutoMapper;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using SocialNGO.Models.Response;

namespace SocialNGO.Profiles;

/// <summary> </summary>
public class AutoMapperProfile : Profile
{
    /// <summary> </summary>
    public AutoMapperProfile()
    {
        CreateMap<LoginModel, UserLoginResponse>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
                 .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.Username));

    }
}
