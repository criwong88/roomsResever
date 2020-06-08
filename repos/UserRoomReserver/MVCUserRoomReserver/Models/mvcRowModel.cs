using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUserRoomReserver.Models
{
    public class mvcRowModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "El Id usuario es incorrecto | ")]
        [Display(Name ="Usuario")]
        public Nullable<int> idUser { get; set; }
        [Required(ErrorMessage = "El Id Salon es Incorrecto | ")]
        [Display(Name = "Salon")]
        public Nullable<int> idRoom { get; set; }
        [Required(ErrorMessage = "La fecha es Incorrecta | ")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public Nullable<System.DateTime> dateReserve { get; set; }
        [Required(ErrorMessage = "Seleccione un motivo | ")]
        [Display(Name = "Motivo")]
        public string destinationReserve { get; set; }
        [Display(Name = "Observaciones")]
        public string observations { get; set; }
        [Required(ErrorMessage = "Confirme el estado de la reserva | ")]
        [Display(Name = "Estado")]
        public Nullable<int> stateReserve { get; set; }
        [Required(ErrorMessage = "Confirme la cantidad de Personas | ")]
        [Display(Name = "Personas")]
        public Nullable<int> numberPerson { get; set; }
    }
}