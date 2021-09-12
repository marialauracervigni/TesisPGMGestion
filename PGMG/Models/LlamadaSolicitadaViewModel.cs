using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class LlamadaSolicitadaViewModel
    {
        public int LlamadaSolicitadaId { get; set; }
        //public int LlamadaSolicitadaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Empleado")]
        public string NombreEmpleado { get; set; }
        public string Observaciones { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        public string Usuario { get; set; }

        public string UsuarioTelef { get; set; }

        public int EstadoLlamadaId { get; set; }
        [Display(Name = "Estado llamada")]
        public string EstadoLlamada { get; set; }
        public bool Respuesta { get; set; }
        public int? LlamadaId { get; set; }
        public bool Activo { get; set; }
        public int Cantidad { get; set; }
    }
}