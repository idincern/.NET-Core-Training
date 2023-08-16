using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    // [NonController] ile işaretlenirse sıradan bir sınıf oluyor, istek karşılayamıyor. controllerdan inherit edilse de noncontroller ile işaretleniyor.
    public class ProductController : Controller // Controller'ların yegane amacı gelen istekleri karşılamaktır. => işin komutanı, yönlendiricisi
                                                // Daha sonra içindeki (fonksiyonlar)Actionlar gerekli operasyonları tetikler => Model, API ya da servisleri tetikleyecek, iş yapacak
    {
        public ActionResult GetProducts() // https://localhost:5001/product/getproducts bu adrese girince burası tetiklenir.
        {
            // Controller burada modele gider bağlanır verileri çeker verileri hazırlar ve viewe gönderir. farklı veri gönderme tipleri de vardır.
            // gönderilen veriler viewde cshtmlde işlenir ve cliente gönderilir.
            Product product = new Product();
            product.Id = 0;
            product.ProductName = string.Empty;
            product.Quantity = 0;

            X(); // NonAction attribute function

            // 1.yol    ViewResult result = new ViewResult();  zaten ProductController içerisindeki GetProducts() metodunda olduğumuz için direkt GetProducts.cshtml'i döndürür.
            ViewResult result = View("GetProducts", product); // 2.yol
            return result; // controllerın clienta response etmesi return işlemidir
// 3.yol    return View(); zaten ProductController içerisindeki GetProducts() metodunda olduğumuz için direkt GetProducts.cshtml'i döndürür.
        }

        [NonAction] // NonAction attribute ile işaretlenen fonksiyonlar dışarıdan request karşılamazlar
        public void X()
        {
             // Bu metod bir action değildir sadece operasyonel iş mantığı yürüten operasyonel bir fonksiyondur
             // Controller'daki actionlar içerisinde kullanılması gereken operatif fonksiyonlar => Algoritma barındıran/ iş mantığı yürüten bir fonksiyon

            // ÖRN: Microservices'ta event yapılanması => kuyruğa gelen mesajın tükteilebilmesi için mesaj geldiği anda bu iş mantığına sahip fonksiyon tetiklenir
            // MVC yapılanmasında bu şekilde tasarım varsa sorgulanmalıdır. Web uygulamalarında başka class/serviste tanımlayıp ilgili actionda çağırmak daha şık olur.
        }
    }
}
