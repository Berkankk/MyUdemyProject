﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); //akış oluşturduk
            await file.CopyToAsync(stream);  //dosyayı kopyaladık
            var bytes = stream.ToArray();    //akıştaki doyayı byte olarak tutuyorum 

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:9795/api/FileImage", multipartFormDataContent);

            if(responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            return View();
        }
    }
}
