using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
        public ViewResult Contact()
        {
            dynamic data = new ExpandoObject();
            data.id = "Mobile";
            data.num = 9800384120;
            ViewBag.Mobile = 9800384120;
            ViewBag.Data = data;
            return View();
        }
    }
}
