using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCUserRoomReserver.Models
{
    public class mvcUserModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Falta el campo Nombre | ")]
        [Display(Name ="Nombre")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "Telefono incorrecto | ")]
        [StringLength(10, ErrorMessage = "Telefono debe tener entre 7 y 10 digitos | ", MinimumLength = 7)]
        [Display(Name = "Telefono")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Correo incorrecto | ")]
        [EmailAddress(ErrorMessage = "Correo incorrecto | ")]
        [Display(Name = "Correo")]
        public string email { get; set; }
        [Required(ErrorMessage = "Falta el campo Departamento | ")]
        [StringLength(50)]
        [Display(Name = "Departamento")]
        public string state { get; set; }
        [Required(ErrorMessage = "Falta el campo Ciudad | ")]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string city { get; set; }
        [Required(ErrorMessage = "Edad Incorrecto | ")]
        [Display(Name = "Edad")]
        public Nullable<int> age { get; set; }
        [Required(ErrorMessage = "Documento incorrecto | ")]
        [StringLength(13, ErrorMessage = "Documento debe contener entre 6 y 13 digitos | ",MinimumLength = 6)]
        [Display(Name = "Documento")]
        public string cc { get; set; }
    }
}