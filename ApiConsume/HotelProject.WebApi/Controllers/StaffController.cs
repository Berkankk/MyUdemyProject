using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet] // herhangi bir paramaetrrem yok direkt olarak verileri listelemek istiyoruz o yüzden get kullandık

        public IActionResult StaffList()
        {
            var value = _staffService.TGetList();
            return Ok(value);
        }

        [HttpPost] //YEni veri girişi yapmak için post kullanırız

        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }

        [HttpDelete("{id}")] // Sİlme işlemi için kullancağız

        public IActionResult DeleteStaff(int id)
        {
            var value = _staffService.TGetByID(id);
            _staffService.TDelete(value);
            return Ok();
        }

        [HttpPut] //Update güncelleme işlemlerimizi yapacağız

        public IActionResult UpdateStaff(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }

        [HttpGet("{id}")] //id ye göre listeleme işlemlerimizi yapmak için kullanırız 

        public IActionResult GetStaff(int id)
        {
            var values=  _staffService.TGetByID(id);
            return Ok(values);
        }

        [HttpGet("Last4Staff")]   //Bu şekilde tanımlamış olduğum metoda istek atıyoruz
        public IActionResult Last4Staff()
        {
            var values = _staffService.TLast4Staff();
            return Ok(values);
        }
    }


}

