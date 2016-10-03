using System.Web.Mvc;

namespace Ugroop.API.SQL.Controllers {


    public class HomeController : Controller {

        private const string URL = "http://localhost:46013/Test/TestAAA";

        public ActionResult Index() {

            ViewBag.Title = "Home Page";

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(URL);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.GetAsync("").Result;

            //if (response.IsSuccessStatusCode) {
            //    var dataObjects = response.Content.ReadAsStringAsync().Result;
            //    ViewBag.Data = dataObjects;
            //}

            return View();
        }
    }
}
