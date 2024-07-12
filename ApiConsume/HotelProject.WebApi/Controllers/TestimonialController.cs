using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet] // herhangi bir paramaetrrem yok direkt olarak verileri listelemek istiyoruz o yüzden get kullandık

        public IActionResult TestimonialList()
        {
            var value = _testimonialService.TGetList();
            return Ok(value);
        }

        [HttpPost] //YEni veri girişi yapmak için post kullanırız

        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TInsert(testimonial);
            return Ok();
        }

        [HttpDelete("{id}")] // Sİlme işlemi için kullancağız

        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok();
        }

        [HttpPut] //Update güncelleme işlemlerimizi yapacağız

        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }

        [HttpGet("{id}")] //id ye göre listeleme işlemlerimizi yapmak için kullanırız 

        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }
    }
}
