using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class LlamadasSolicitadasHist
    {
        public int LlamadasSolicitadasHistId { get; set; }

        public int LlamadaSolicitadaId { get; set; }

        [Display(Name = "ID Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public Cliente ClienteLlamadaSolic { get; set; }

        [Display(Name = "Cliente")]
        public string NombreCliente { get; set; }


        public DateTime Fecha { get; set; }


        public DateTime Hora { get; set; }

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
        public bool Respuesta { get; set; }
        public int? LlamadaId { get; set; }
        public bool Activo { get; set; }


    }
}