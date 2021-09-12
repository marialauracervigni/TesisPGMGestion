using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MvcValidationExtensions.Attribute;

namespace PGMG.Models
{
    public class ReporteLlamadasViewModel
    {
        public int ClienteId { get; set; }
        [Display(Name = "Nombre cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha desde")]
        [LessThanEqualTo("Hasta", ErrorMessage = "La fecha desde no puede ser mayor a la fecha hasta.")]
        [Display(Name = "Fecha desde")]
        public DateTime Desde { get; set; }

        [GreaterThanEqualTo("Desde", ErrorMessage = "La fecha hasta no puede ser menor a la fecha desde.")]
        [Required(ErrorMessage = "Debe ingresar una fecha hasta")]
        [Display(Name = "Fecha hasta")] 
        public DateTime Hasta { get; set; }

        public string Usuario { get; set; }

    }
}