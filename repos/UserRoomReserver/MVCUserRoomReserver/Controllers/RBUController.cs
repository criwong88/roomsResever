using MVCUserRoomReserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class RBUController : Controller
    {
        // GET: RBU
        public ActionResult Index(string idr, string phone)
        {
            IEnumerable<mvcRBUModel> fiList;
            HttpResponseMessage respose = GlobalVariables.WebApiClient.GetAsync("RBU_view").Result;

            ViewBag.idr = idr;
            ViewBag.phone = phone;

            if (string.IsNullOrEmpty(idr))
            {
                fiList = respose.Content.ReadAsAsync<IEnumerable<mvcRBUModel>>().Result;
                return View(fiList);
            }
            else
            {
                fiList = respose.Content.ReadAsAsync<IEnumerable<mvcRBUModel>>().Result;
                return View(fiList.Where(model => model.Expr1.ToString().ToLower().Contains(idr)));
            }
        }
    }
}