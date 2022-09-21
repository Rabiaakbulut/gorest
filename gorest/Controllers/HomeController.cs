using gorest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace gorest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserList()
        {
            IEnumerable<ApiModel> user = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://gorest.co.in/public/v2/users");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    user = JsonConvert.DeserializeObject<List<ApiModel>>(result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    user = Enumerable.Empty<ApiModel>();
                    ModelState.AddModelError(string.Empty, "server error occured");
                }
            }
            return View(user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}