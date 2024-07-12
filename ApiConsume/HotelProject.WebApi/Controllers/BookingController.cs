using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet] // herhangi bir paramaetrrem yok direkt olarak verileri listelemek istiyoruz o yüzden get kullandık

        public IActionResult BookingList()
        {
            var value = _bookingService.TGetList();
            return Ok(value);
        }

        [HttpPost] //YEni veri girişi yapmak için post kullanırız

        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete] // Silme işlemi için kullancağız

        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut("UpdateBooking")] //Update güncelleme işlemlerimizi yapacağız

        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")] //id ye göre listeleme işlemlerimizi yapmak için kullanırız 

        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        //[HttpPut("aaaaa")]
        //public IActionResult aaaaa(Booking booking)
        //{
        //    _bookingService.TBookingStatusChangeApproved(booking);
        //    return Ok();
        //}

        //[HttpPut("bbbb")]
        //public IActionResult bbbb(int id)
        //{
        //    _bookingService.TBookingStatusChangeApproved2(id);
        //    return Ok();
        //}

        [HttpGet("Last6Bookings")]
        public IActionResult Last6Bookings()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);
        }

        [HttpGet("BookingApproved")]   //bizim için olayı tetikleyen aksiyon
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved3(id);
            return Ok();
        }
        [HttpGet("BookingCancel")]   //bizim için olayı tetikleyen aksiyon
        public IActionResult BookingCance(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("BookingWait")]   //bizim için olayı tetikleyen aksiyon
        public IActionResult BookingWait(int id)
        {
            _bookingService.TBookingStatusChangeWaitl(id);
            return Ok();
        }
    }
}
