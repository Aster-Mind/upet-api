using AutoMapper;
using UpetApi.DTOS;
using UpetApi.Entidades;

namespace UpetApi.Helpers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<UserCreacionDTO, Users>().ReverseMap();
            CreateMap<LoginUserDTO, Users>();
        }
    }
}
