using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListUserWebApplication.Models;
using ListUserWebApplication.Helper;
using ListUserWebApplication.Model;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

namespace ListUserWebApplication.Controllers
{
    public class HomeController : Controller
    {
        UserAPI _api = new UserAPI();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RegisteredUsers()
        {
            List<UsersViewModel> users = new List<UsersViewModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/User");
            
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UsersViewModel>>(result);

            }
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUsers(UsersViewModel userModel)
        {
            HttpClient client = _api.Initial();
            List<UsersViewModel> users = new List<UsersViewModel>();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            response = client.PostAsJsonAsync("api/User/", userModel).Result;
            if (response.IsSuccessStatusCode)
            {
                //return this.RedirectToAction("RegisteredUsers");
                var result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<UsersViewModel>>(result);
            }

            return this.Json(users);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
