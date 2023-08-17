using Microsoft.AspNetCore.Mvc;
using mvc_tutorial1.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace mvc_tutorial1.Controllers
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
            var productsList = new List<Product>()
            {
                new Product{Id=1, ProductName="First Product", Quantity=9},
                new Product{Id=2, ProductName="Second Product", Quantity=19},
                new Product{Id=3, ProductName="Third Product", Quantity=29},
            };
            #region Model bazlı veri gönderimi
            //return View(productsList);
            #endregion
            #region Veri taşıma kontrolleri // Bu Controllerın da inherit edildiği Controller base classında tanımlanmıştır(librarye bak)
            #region 1) ViewBag
            // View'e gönderilecek(taşınacak) datayı dynamic bir şekilde tanımlanan
            // bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.
            ViewBag.products = productsList; // burada dynamic olarak değişken tanımlanıyor. viewde model bazlı değil artık dinamik olarak çalışıyoruz.
            #endregion

            #region 2) ViewData
            // ViewBag'de olduğu gibi actiondaki datayı view'e taşımayı sağlayan bir veri taşıma kontrolüdür.
            // Farkı ViewBag'de tanımlanan değişkenin dynamic olmasıdır. ViewData'da ise tanımlanan değişkenin tipi object'tir=> boxing yaparak taşır.
            // Dolayısıyla viewde unboxing yaparak kullanılabilir.
            ViewData["productsList"] = productsList; //burada object türünde bir değişken tanımlanıyor. viewde cast ya da as operatörleriyle unboxing yaparak kullanılabilir.
            #endregion

            #region 3) TempData
            // (aynı) ViewData'da olduğu gibi actiondaki datayı view'e taşımayı sağlayan bir veri taşıma kontrolüdür.
            // boxing unboxing olayı bunun için de geçerlidir.
            // Farkı ise TempData'nın bir sonraki request'e kadar datayı tutmasıdır. ViewData ve ViewBag'de ise sadece bir request boyunca tutulur.
            // En önemli farkı: TempData cookiler üzerinden çalışır, redirect işlemine izin verir. ViewData ve ViewBag ise session üzerinden çalışır.
            // Farklı yönlendirmeler ile farklı actionlara bu veri taşınabilir
            string data = JsonSerializer.Serialize(productsList); // kompleks veri tipleri redirect edilirken serialize işlemine uğratılmalıdır.
            TempData["productsList"] = data;
            #endregion
            #endregion
            return RedirectToAction("TestActionRedirect", "Home"); // alttaki actiona yönlendirir
            // NOT: buradaki gibi kompleks veri tipleri redirect edilirken serialize işlemine uğratılmalıdır.
            // Bunun için JsonSerialize kullanılabilir. (Newtonsoft.Json paketi)
        }
        public IActionResult TestActionRedirect()
        {
            var data = TempData["productsList"] as string; // kompleks veri tipleri redirect edilirken serialize işlemine uğratılmalıdır.
            List<Product> productsList =  JsonSerializer.Deserialize<List<Product>>(data); // ilgili değerler başka bir actiondan buraya taşındı
            TempData["productsList"] = productsList;
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
            #region Model bazlı veri gönderimi
            // listeyi viewe gönderdik. view başlangıcında da tanımlanması gerekir. view bu gönderilen modeli kullanır ve ona göre şekillenir.
            return View(products);
            #endregion



        }
    }
}
