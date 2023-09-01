using Microsoft.AspNetCore.Mvc;
using mvc_tutorial1.Models;

namespace mvc_tutorial1.Controllers
{
    public class ModelBindingController:Controller
    {
        //https://localhost:5001/modelbinding/getdatafromuser
        public IActionResult GetDataFromUser() // httpget request
        {
            var model = new ModelToBeBinded()
            {
                Name = "Default Name",
                Quantity = 1
            };
            return View(model); // bu model alttaki forma ilk değer olarak gönderilir,
                                // form doldurulduğunda bu modeldeki propertyler doldurulur.
        }

        [HttpPost]
        public IActionResult GetDataFromUser(ModelToBeBinded incomingModel)   // httppost request
        {
            // Form içindeki input nesneleri post edildiğinde bu nesnelere
            // karşılık gelen propertyleri karşılayan nesne ile otomatik olarak bind edilirler.
            var x = incomingModel.Name;
            var y = incomingModel.Quantity;
            return View(incomingModel);
        }

        public class Data{
            public string A { get; set; }
            public string B { get; set; }
        }
        public IActionResult GetData(Data data)   // querystring ile veri alma 2. yol: Data class'ı ile bağlamak 
        {
            // https://localhost:5001/ModelBinding/GetData?a=ali&b=veli => querystring linki: a ve b parametreleri görünür halde bunu engellemek için Route Parameter ile veri alınması yapılabilir

            var queryString = Request.QueryString; // Request yapılan endpointe QueryString parametresi
                                                   // eklenmiş mi eklenmemiş mi bununla ilgili bilgi verir(HasValue) ve Value propertyleri kontrol edilebilir

            var a = Request.Query["a"].ToString(); // a = ali
            var b = Request.Query["b"].ToString(); // b = veli

            return View();
        }

        // https://localhost:5001/ModelBinding/GetDataOverRouteParameter/5 => routeparam = 5
        public IActionResult GetDataOverRouteParameter(int routeParam)   // Route parameteres ile ... /controller/id şeklinde veri alınabilir, yine bir model class ile karşılanabilir 
        {
            var values = Request.RouteValues; 
            var controller = values["controller"].ToString(); // controller = ModelBinding
            var action = values["action"].ToString();         // action = GetDataOverRouteParameter
            var id = values["id"].ToString();                 // id = 5

            return View();
        }

        // Startup'taki endpoints.MapControllerRoute(name: "CustomRoute", pattern: "{controller = Home}/{action = Index}/{a}/{b}/{id}");
        // https://localhost:5001/ModelBinding/GetDataOverMapControllerRoute/ahmet/mehmet/5 
        public IActionResult GetDataOverMapControllerRoute(int id, string a, string b)   // Startup.cs'de bu yol önceden tanımlanmış olmalıdır. Ona uyarak veri alınır.
        {
            var values = Request.RouteValues;
            var controller = values["controller"].ToString(); // controller = ModelBinding
            var action = values["action"].ToString();         // action = GetDataOverRouteParameter
            var id2 = values["id"].ToString();                // id = 5
            var a2 = values["a"].ToString();                  // a = ahmet
            var b2 = values["b"].ToString();                  // b = mehmet

            return View();
        }

    }
}
