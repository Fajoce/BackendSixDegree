using AutoMapper;
using Entities;
using Entities.DTO;

namespace Domain
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<User, UserDTO>()
                .ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.UserId)
                )
                .ForMember(
                dest => dest.UserLastName,
                opt => opt.MapFrom(src => src.UserLastName)
                )
                 .ForMember(
                dest => dest.UserAdress,
                opt => opt.MapFrom(src => src.UserAdress)
                )
                  .ForMember(
                dest => dest.UserTelephone,
                opt => opt.MapFrom(src => src.UserTelephone)
                )
                   .ForMember(
                dest => dest.UserEmail,
                opt => opt.MapFrom(src => src.UserEmail)
                );
        }
    }
}

