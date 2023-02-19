using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Domain.Entites.Identity;

namespace Application.Features.Auth.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterCommandRequest, User>();

        }
    }
}
