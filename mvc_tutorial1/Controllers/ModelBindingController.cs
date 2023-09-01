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
            // https://localhost:5001/ModelBinding/GetData?a=ali&b=veli => querystring linki

            var queryString = Request.QueryString; // Request yapılan endpointe QueryString parametresi
                                                   // eklenmiş mi eklenmemiş mi bununla ilgili bilgi verir(HasValue) ve Value propertyleri kontrol edilebilir

            var a = Request.Query["a"].ToString(); // a = ali
            var b = Request.Query["b"].ToString(); // b = veli

            return View();
        }
    }
}
