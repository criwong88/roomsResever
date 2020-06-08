using MVCUserRoomReserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            IEnumerable<mvcRoomModel> roList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Rooms").Result;
            roList = response.Content.ReadAsAsync<IEnumerable<mvcRoomModel>>().Result;
            
            return View(roList);
        }

        //Post add or Put edit
        public ActionResult AddOrEditRoom(int id=0)
        {
            if (id == 0)
            {
                return View(new mvcRoomModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Rooms/"+ id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcRoomModel>().Result);
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEditRoom(mvcRoomModel ro)
        {
            if(ro.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Rooms", ro).Result;
                TempData["SuccessMessage"] = "el Salón Se Creó de manera correcta";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Rooms/"+ ro.id,ro).Result;
                TempData["SuccessMessage"] = "el Salón Se Actualizó de manera correcta";
            }
                
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Rooms/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Se ha eliminado el Salon de manera correcta";
            return RedirectToAction("Index");
        }
    }

    
}