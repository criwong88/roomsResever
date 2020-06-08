using MVCUserRoomReserver.Models;
using MVCUserRoomReserver.Models.db_model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCUserRoomReserver.Controllers
{
    public class RowController : Controller
    {
        reserveRoomEntities1 DB = new reserveRoomEntities1();
        // GET: Row
        public ActionResult Index(string idr)
        {
            

            if (string.IsNullOrEmpty(idr))
            {
                IEnumerable<mvcRowModel> rrList;
                HttpResponseMessage respose = GlobalVariables.WebApiClient.GetAsync("Rows").Result;
                rrList = respose.Content.ReadAsAsync<IEnumerable<mvcRowModel>>().Result;

                return View(rrList);
            }
            else
            {
                IEnumerable<mvcRowModel> rrList;
                HttpResponseMessage respose = GlobalVariables.WebApiClient.GetAsync("Rows").Result;
                rrList = respose.Content.ReadAsAsync<IEnumerable<mvcRowModel>>().Result;

                ViewBag.idr = idr;
                return View(rrList.Where(model => model.destinationReserve.ToString().ToLower().Contains(idr)));
            }

            
        }

      

        //Post add or Put edit
        public ActionResult AddOrEditRow(int id = 0)

        {
            List<sp_getRooms_Result> rl = DB.sp_getRooms().ToList();
            List<sp_getUsers_Result> ul = DB.sp_getUsers().ToList();

            List<SelectListItem> roomlist = rl.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.roomName.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> userlist = ul.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.fullName.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };
            });

            ViewBag.roomlist = roomlist;
            ViewBag.userlist = userlist;

            if (id == 0)
            {
                return View(new mvcRowModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Rows/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcRowModel>().Result);
            }

        }

        [HttpGet]
        public ActionResult AddOrEditRowByUser(int id, string name)
        {
            List<sp_getRooms_Result> rl = DB.sp_getRooms().ToList();
            List<sp_getUsers_Result> ul = DB.sp_getUsers().ToList();

            List<SelectListItem> roomlist = rl.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.roomName.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };
            });

            List<SelectListItem> userlist = ul.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.fullName.ToString(),
                    Value = d.id.ToString(),
                    Selected = false
                };
            });

            ViewBag.roomlist = roomlist;
            ViewBag.userlist = userlist;

            Debug.WriteLine(id);
            ViewBag.idr = id;
            ViewBag.name = name;

            return View(new mvcRowModel());

        }

        [HttpPost]
        public ActionResult AddOrEditRowByUser(mvcRowModel rr)
        {
            Debug.WriteLine(rr.idUser);
            HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Rows", rr).Result;
            TempData["SuccessMessage"] = "Se realizo la reserva de manera correcta";

            return Redirect("~/User");

        }

        [HttpPost]
        public ActionResult AddOrEditRow(mvcRowModel rr)
        {
            if (rr.id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Rows", rr).Result;
                TempData["SuccessMessage"] = "Se realizo la reserva de manera correcta";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Rows/" + rr.id, rr).Result;
                TempData["SuccessMessage"] = "Se cambio la reserva de Manera correcta";
            }

            return Redirect("~/User");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Rows/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Se ha cancelado la Reserva";
            return Redirect("~/User");
        }
    }
}