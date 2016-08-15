using System.Web.Mvc;

namespace Ugroop.API.Controllers {


    public class HomeController : Controller {

        //private const string URL = "http://localhost:46013/api/Test/TestAAA";
        private const string URL = "http://localhost:46013/Test/TestAAA";

        //private ISettingService _settingService;

        //public HomeController(ISettingService settingService) {
        //    _settingService = settingService;
        //}

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
