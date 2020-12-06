using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RWFM.Models;
using RWFM.Repositories;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace RWFM.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserRepository userRepository;
        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> login(){
            string json;
            using (StreamReader reader 
                  = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                json = await reader.ReadToEndAsync();
            }

            
            

            LoginRequestModel loginRequest = JsonConvert.DeserializeObject<LoginRequestModel>(json);
            HttpContext.Session.SetInt32("userID", 0);
            userRepository = UserRepository.GetInstance();
            userRepository.GetUserByUsername(loginRequest.Username);
            return true;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
