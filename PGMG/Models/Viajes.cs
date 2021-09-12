using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MvcValidationExtensions.Attribute;

namespace PGMG.Models
{
    public class Viajes
    {
        public int ViajesId { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un cliente")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [Display(Name = "Fecha desde")]
        [LessThanEqualTo("FechaHasta", ErrorMessage = "La fecha desde no puede ser mayor a la fecha hasta.")]
        public DateTime FechaDesde { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [Display(Name = "Fecha hasta")]
        [GreaterThanEqualTo("FechaDesde", ErrorMessage = "La fecha hasta no puede ser menor a la fecha desde.")]
        public DateTime FechaHasta { get; set; }

        public string Usuario { get; set; }
        public string Observaciones { get; set; }

        public bool Confirmado { get; set; }
        public bool Realizado { get; set; }
    }
}