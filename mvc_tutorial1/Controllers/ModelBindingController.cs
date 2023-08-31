using Microsoft.AspNetCore.Mvc;
using mvc_tutorial1.Models;

namespace mvc_tutorial1.Controllers
{
    public class ModelBindingController:Controller
    {
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
            return View(incomingModel);
        }
    }
}
