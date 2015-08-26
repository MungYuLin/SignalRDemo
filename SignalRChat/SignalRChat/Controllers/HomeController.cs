using Microsoft.AspNet.SignalR;
using Owin;
using SignalRChat.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TimeShow()
        {
            return View();
        }

        public ActionResult UserDate()
        {
            return View();
        }

        public ActionResult ShowUsers()
        {
            return View();
        }
    }
}