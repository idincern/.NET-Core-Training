using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller // Controller classından türetilince bir requesti karşılayabilir, response döndürebilir.
    {
        // Controller sınıfları içerisindeki metodlara Action Metod denir.  => gelen isteği karşılayan ve gerekli operasyonları gerçekleştiren metod.
        public IActionResult Index()
        {
            return View();
        }
    }
}
