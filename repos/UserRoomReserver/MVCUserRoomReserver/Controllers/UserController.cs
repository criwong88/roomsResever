using MVCUserRoomReserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            IEnumerable<mvcUserModel> usList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users").Result;
            usList = response.Content.ReadAsAsync<IEnumerable<mvcUserModel>>().Result;
            return View(usList);
        }

        public ActionResult AddOrEdit(int id =0)
        {
            if (id==0)
            {
                return View(new mvcUserModel());
            }            
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Users/"+ id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcUserModel>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(mvcUserModel us)
        {
            if (us.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Users", us).Result;
                TempData["SuccessMessage"] = "Se Creó Corretamente el Usuario";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Users/"+ us.id,us).Result;
                TempData["SuccessMessage"] = "el Usuario Se Actualizó de manera correcata";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Users/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Se ha eliminado el Usuario de manera correcta";
            return RedirectToAction("Index");
        }
    }
}