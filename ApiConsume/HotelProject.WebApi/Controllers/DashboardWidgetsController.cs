using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetsController : ControllerBase
    {
        //Burası apimizde istek atmamızı ve consume edilme işlemlerini dashboard için yapacak

        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;
        public DashboardWidgetsController(IStaffService staffService, IRoomService roomService, IBookingService bookingService, IAppUserService appUserService)  //Burada amacımızı istek sonucunda sayı dönmek
        {
            _staffService = staffService;
            _roomService = roomService;
            _bookingService = bookingService;
            _appUserService = appUserService;
        }

        [HttpGet("StaffCount")]
        public IActionResult StaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }

        [HttpGet("BookingCount")]
        public IActionResult BookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }

        [HttpGet("AppUserCount")]
        public IActionResult AppUserCount()
        {
            var value = _appUserService.TAppUserCount();
            return Ok(value);
        }

        [HttpGet("RoomCount")]
        public IActionResult RoomCount()
        {
            var value = _roomService.TRoomCount();
            return Ok(value);
        }

    }
}
