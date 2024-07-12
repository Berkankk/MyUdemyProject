using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebApi.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //İki sınıfı burada automapper ile eşitledik 
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();
            //bu sayede dto sınıfı ile entity katmanında proplarımız birbirine eşitlenmiş oldu

            

        }
    }
}
