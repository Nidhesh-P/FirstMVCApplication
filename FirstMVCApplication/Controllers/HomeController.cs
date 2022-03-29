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

        public ActionResult Edit(int? id, string name, string type)
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider() {ProviderId =id??0, ProviderType = type, ProviderName = name });
        }

        public ActionResult Delete(int? id, string name, string type)
        {
            ViewBag.Message = "Your contact page.";

            return PartialView(new Provider() { ProviderId = id ?? 0, ProviderType = type, ProviderName = name });
        }

        [HttpPost]
        public ActionResult Edit(Provider p)        
        {
            if (ModelState.IsValid)
            {

                Provider newP = p;
                p.UpdateProvider(p);
            }

            return RedirectToAction("ShowProviders");
        }

        [HttpPost]
        public ActionResult Delete(Provider p)
        {
            if (ModelState.IsValid)
            {

                Provider.DeleteProvider(p.ProviderId);
            }

            return RedirectToAction("ShowProviders");
        }

        public ActionResult ShowProviders()
        {
            List<Provider> p = new List<Provider>();

            var dataTables = Provider.GetProviderData();

            foreach (DataRow data in dataTables.Tables[0].Rows)
            {
                //Provider newProvider = new Provider()
                //{
                //    ProviderId = Convert.ToInt32(data[0].ToString()),
                //    ProviderName = data[1].ToString(),
                //    ProviderType = data[2].ToString()
                //};

                //p.Add(newProvider);

                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }

            return View(p);
        }
    }
}