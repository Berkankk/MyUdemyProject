using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //consume edilmesi için istemci oluşturduk
            var responseMessage = await client.GetAsync("http://localhost:9795/api/Staff");
            if (responseMessage.IsSuccessStatusCode)  //dönen response başarılı mı değil mi onu kontrol eder
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData); //Json türünde gelen datayı listelemek için deserilaze metodunu kullandık 
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel); //parametreden gelen değeri serilaze ettik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:9795/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode) //başarılı dönerse beni index e geri yönlendir
            {
                return RedirectToAction("Index");
            }
            return View();
        }

      
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:9795/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id) //burada güncelleyeceğimiz verileri getiririz herahngi bir güncelleme işlemi yapmayız
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:9795/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // veri listeledik 
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values); //başarılı olursa valuesi dön geri
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel viewModel) //burada güncelleyeceğimiz verileri getiririz herahngi bir güncelleme işlemi yapmayız
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(viewModel);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json" );
            var responseMessage = await client.PutAsync("http://localhost:9795/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
