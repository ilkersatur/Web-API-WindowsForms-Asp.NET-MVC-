using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            HttpClient istemci = new HttpClient();
            string data = istemci.GetStringAsync("http://localhost:5184/api/Urun").Result;
            var urunler = JsonConvert.DeserializeObject<List<Urun>>(data);
            return View(urunler);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Urun urun)
        {
            HttpClient istemci = new HttpClient();

            var resp = istemci.PostAsJsonAsync("http://localhost:5184/api/Urun", urun).Result;
            if (resp.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Hata",resp.Content.ReadAsStringAsync().Result);
                return View();
            }
        }
    }
}