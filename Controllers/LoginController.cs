using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RWFM.Models;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace RWFM.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async void login(){
            string json;
            using (StreamReader reader 
                  = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    json = await reader.ReadToEndAsync();
                }

            LoginRequestModel loginRequest = JsonConvert.DeserializeObject<LoginRequestModel>(json);
            HttpContext.Session.SetInt32("userID", 0);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
