using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult GetProducts() // https://localhost:5001/product/getproducts bu adrese girince burası tetiklenir.
        {
            // Controller burada modele gider bağlanır verileri çeker verileri hazırlar ve viewe gönderir. farklı veri gönderme tipleri de vardır.
            // gönderilen veriler viewde cshtmlde işlenir ve cliente gönderilir.
            Product product = new Product();
            product.Id = 0;
            product.ProductName = string.Empty;
            product.Quantity = 0;

// 1.yol    ViewResult result = new ViewResult();
            ViewResult result = View("GetProducts", product); // 2.yol
            return result; // controllerın clienta response etmesi return işlemidir
// 3.yol    return View();
        }
    }
}
