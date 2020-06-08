using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUserRoomReserver.Models
{
    public class mvcRBUModel
    {
        [Display(Name ="id")]
        public int id { get; set; }
        [Display(Name = "IdUser")]
        public int Expr1 { get; set; }
        [Display(Name = "Nombre")]
        public string fullName { get; set; }
        [Display(Name = "Documento")]
        public string cc { get; set; }
        [Display(Name = "Ciudad")]
        public string city { get; set; }
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> dateReserve { get; set; }
        [Display(Name = "Personas")]
        public Nullable<int> numberPerson { get; set; }
        [Display(Name = "Motivo")]
        public string destinationReserve { get; set; }
        [Display(Name = "Estado")]
        public Nullable<int> stateReserve { get; set; }
        [Display(Name = "IdRoom")]
        public Nullable<int> idRoom { get; set; }
        [Display(Name = "Salon")]
        public string roomName { get; set; }
    }
}