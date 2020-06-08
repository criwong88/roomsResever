using MVCUserRoomReserver.Models.db_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class spRBDController : Controller
    {
        reserveRoomEntities1 DB = new reserveRoomEntities1();
        // GET: spRBD
        public ActionResult Index(string fi, string ff)
        {
            DateTime dfi;
            DateTime dff;

            if (string.IsNullOrEmpty(fi) && string.IsNullOrEmpty(ff))
            {
                dfi = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                dff = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            }
            else
            {
                dfi = Convert.ToDateTime(fi);
                dff = Convert.ToDateTime(ff);
            }

            ViewBag.fi = dfi.ToString("dd-MM-yyyy");
            ViewBag.ff = dff.ToString("dd-MM-yyyy");

            return View(DB.sp_RBD(dfi,dff ).ToList().Where(model => model.stateReserve.ToString().ToLower().Contains("1")));
        }
    }
}