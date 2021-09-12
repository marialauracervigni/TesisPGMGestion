using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PGMG.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Roles")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }

        //[Display(Name = "Fecha de nacimiento")]
        //public DateTime FechaNacimiento { get; set; }

        //[Display(Name = "Fecha de ingreso")]
        //public DateTime FechaIngreso { get; set; }

    }

}