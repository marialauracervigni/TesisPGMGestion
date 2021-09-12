using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class LlamadaSolicitada
    {
        public int LlamadaSolicitadaId { get; set; }

        [Display(Name = "ID Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public Cliente ClienteLlamadaSolic { get; set; }

        [Required(ErrorMessage = "Debe ingresar un cliente")]
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debe ingresar una hora")]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "Debe ingresar un empleado")]
        [Display(Name = "Nombre del empleado")]
        public string NombreEmpleado { get; set; }

        public string Usuario { get; set; }

        [Display(Name = "Telefonista")]
        public string UsuarioTelef { get; set; }

        public int EstadoLlamadaId { get; set; }

        [Display(Name = "Estado Llamada")]
        public string EstadoLlamada { get; set; }

        [Display(Name = "Estado Llamada")]
        public EstadoLlamada EstadLlamada { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        public string Observaciones { get; set; }

        [Display(Name = "Forma de comunicacion")]
        public int FormaDeComunicacionId { get; set; }

        [Display(Name = "Forma de comunicación")]
        public ICollection<FormaDeComunicacion> FormaDeComunicacion { get; set; }
        public bool Respuesta { get; set; }
        public int? LlamadaId { get; set; }
        public bool Activo { get; set; }
    }
}