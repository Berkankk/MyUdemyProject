using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet] // herhangi bir paramaetrrem yok direkt olarak verileri listelemek istiyoruz o yüzden get kullandık

        public IActionResult AboutList()
        {
            var value = _aboutService.TGetList();
            return Ok(value);
        }

        [HttpPost] //YEni veri girişi yapmak için post kullanırız

        public IActionResult AddAbout(About about)
        {
            _aboutService.TInsert(about);
            return Ok();
        }

        [HttpDelete] // Sİlme işlemi için kullancağız

        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok();
        }

        [HttpPut] //Update güncelleme işlemlerimizi yapacağız

        public IActionResult UpdateAbout(About about)
        {
            _aboutService.TUpdate(about);
            return Ok();
        }

        [HttpGet("{id}")] //id ye göre listeleme işlemlerimizi yapmak için kullanırız 

        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
