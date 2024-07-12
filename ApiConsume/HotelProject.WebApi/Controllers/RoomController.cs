using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet] // herhangi bir paramaetrrem yok direkt olarak verileri listelemek istiyoruz o yüzden get kullandık

        public IActionResult RoomList()
        {
            var value = _roomService.TGetList();
            return Ok(value);
        }

        [HttpPost] //YEni veri girişi yapmak için post kullanırız

        public IActionResult AddRoom(Room room)
        {
            _roomService.TInsert(room); 
            return Ok();
        }

        [HttpDelete("{id}")] // Sİlme işlemi için kullancağız

        public IActionResult DeleteRoom(int id)
        {
            var value = _roomService.TGetByID(id);
            _roomService.TDelete(value);
            return Ok();
        }

        [HttpPut] //Update güncelleme işlemlerimizi yapacağız

        public IActionResult UpdateRoom(Room room)
        {
            _roomService.TUpdate(room);
            return Ok();
        }

        [HttpGet("{id}")] //id ye göre listeleme işlemlerimizi yapmak için kullanırız 

        public IActionResult GetRoom(int id)
        {
            var value = _roomService.TGetByID(id);
            return Ok(value);
        }
    }
}
