using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstMVCApplication.Models;

namespace FirstMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        public ActionResult ContactUs()
        {
            Provider p = new Provider();

            var data = p.GetProviderData();

            p.ProviderId = Convert.ToInt32(data.Tables[0].Rows[0][0].ToString());
            p.ProviderName = data.Tables[0].Rows[0][1].ToString();
            p.ProviderType = data.Tables[0].Rows[0][2].ToString();

            //ViewData["Orders"] = p;
            //ViewBag.Message = "Good Morning to this page";
            return View(p);
        }
    }
}