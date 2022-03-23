using System;
using System.Collections.Generic;
using System.Data;
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


        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider());
        }

        [HttpPost]
        public ActionResult Create(Provider p)
        {
            if (ModelState.IsValid)
            {

                Provider newP = p;
                p.InsertProvider(p);
            }

            return RedirectToAction("ShowProviders");
        }

        public ActionResult ShowProviders()
        {
            List<Provider> p = new List<Provider>();

            var dataTables = Provider.GetProviderData();
            foreach (DataRow data in dataTables.Tables[0].Rows)
            {
                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }

            //ViewData["Orders"] = p;
            //ViewBag.Message = "Good Morning to this page";
            return View(p);
        }
    }
}