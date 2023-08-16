using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller // Controller classından türetilince bir requesti karşılayabilir, response döndürebilir.
    {
        // Controller sınıfları içerisindeki metodlara Action Metod denir.  => gelen isteği karşılayan ve gerekli operasyonları gerçekleştiren metod.
        
        // Viewlar tanımlanırken Controller(name) / View(name) şeklinde klasörlenerek tanımlanır.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1() // sağ tıkla add view de ve kolayca ilgili dizinde view oluştur.
        {
            return View();
        }
        public IActionResult Index2() // sağ tıkla add view de ve razor view ile dolu bir create/read/update/list view oluştur.
        {
            // Bu products listesinin Modelden geldiğini varsayıyoruz
            List<Product> products = new List<Product>() {
                new Product{Id=1, ProductName="First Product", Quantity=9},
                new Product{Id=2, ProductName="Second Product", Quantity=19},
                new Product{Id=3, ProductName="Third Product", Quantity=29},
            };
            #region Model bazlı gönderim
            // listeyi viewe gönderdik. view başlangıcında da tanımlanması gerekir
            return View(products);
            #endregion



        }
    }
}
