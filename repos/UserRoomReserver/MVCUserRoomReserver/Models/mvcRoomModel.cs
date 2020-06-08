using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUserRoomReserver.Models
{
    public class mvcRoomModel
    {
        [Display(Name ="ID")]
        public int id { get; set; }
        [Required(ErrorMessage = "Campo Requerido | ")]
        [StringLength(50, ErrorMessage = "Nombre del Salon debe contener entre 6 y 50 caracteres | ", MinimumLength = 6)]
        [Display(Name = "Nombre del salon")]
        public string roomName { get; set; }
    }
}