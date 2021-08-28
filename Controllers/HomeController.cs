using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public static string token = "ej72MsQLSFqJuy1CeeOKcM:APA91bHKZU3iIZbBpupk1GUvQDJHRbN4_HPszOx76RyTHK4kyUuJ_3Zys6BQJD1ijrhxUIhumxdrwB57ihVH74f3cIWiXPPo9mDysnaId01Rqy_Cg4ueJXwdXNteRASFHXdTWPyoTNPh";

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
   

        public IActionResult Index()
        {
            SendPushNotification("HELLO","AARIF CODE RUN HO GAYA HAI");
            return View();
        }

        public async void SendPushNotification(string title,string body)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            contentRootPath = contentRootPath+ "\\Firebase\\paymentgateway-6d9d6-firebase-adminsdk-5074p-cc0188afeb.json";
          
            var credential = GoogleCredential.FromFile(contentRootPath);
            var def=  FirebaseApp.Create(new AppOptions()
            {
                Credential = credential
            });
            List<string> clientToken = new List<string>();
            clientToken.Add(token);
            var registrationTokens = clientToken;
            var message = new Message()
            {
               Token = token,
                Notification = new Notification
                {
                    Title = title,
                    Body = body,
                    ImageUrl = "https://www.vastbazaar.com/img/VB.png",
                }
            };
            var response = await FirebaseMessaging.DefaultInstance.SendAsync(message).ConfigureAwait(true);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
