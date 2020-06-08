using MVCUserRoomReserver.Models.db_model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class spRBUController : Controller
    {
        reserveRoomEntities1 DB = new reserveRoomEntities1();
        // GET: spRBU
        public ActionResult Index()
        {
            return View(DB.sp_RBU(11).ToList());
        }
    }
}