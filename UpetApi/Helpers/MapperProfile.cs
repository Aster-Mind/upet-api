using AutoMapper;
using UpetApi.DTOS;
using UpetApi.Entidades;
using UpetApi.Migrations;

namespace UpetApi.Helpers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<UserCreacionDTO, Users>().ReverseMap();
            CreateMap<LoginUserDTO, Users>();

            CreateMap<Sede, SedesDTO>().ReverseMap();
            CreateMap<SedeCreacionDTO, Sede>().ReverseMap();


            CreateMap<Raza, RazaDTO>().ReverseMap();
            CreateMap<RazaCreacionDTO, Raza>().ReverseMap();

            CreateMap<Mascota, MascotasDTO>().ReverseMap();
            CreateMap<MascotasCreacionDTO, Mascota>().ReverseMap();

            CreateMap<OngUsers, OngsDTo>().ReverseMap();
            CreateMap<OngCreacionDTO, OngUsers>().ReverseMap();


        }
    }
}
