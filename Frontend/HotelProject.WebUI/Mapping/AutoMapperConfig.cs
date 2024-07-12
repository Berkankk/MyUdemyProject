using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.AppUserDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Http.Features;
using System.Runtime.CompilerServices;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile 
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            //reverse map metodu karşılıklı olarak onları mapler kulanmasaydık tekrardan aynı metodu yazıp dto ile servisin yerini değiştirecektim
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();

            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultTestimnoialDto, Testimonial>().ReverseMap();

            CreateMap<ResultStaffDto, Staff>().ReverseMap();

            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto , Booking>().ReverseMap();
            CreateMap<ApprovedReservation,Booking>().ReverseMap();  

            CreateMap<CreateGuestDto ,Guest>().ReverseMap();
            CreateMap<UpdateGuestDto ,Guest>().ReverseMap();

            CreateMap<ResultAppUserDto , AppUser>().ReverseMap();

            //CreateMap<InboxContactDto , Contact>().ReverseMap();


        }

    }
}
