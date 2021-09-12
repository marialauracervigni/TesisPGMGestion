using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class LlamadaHist
    {
        public int LlamadaHistId { get; set; }
        public int LlamadaId { get; set; }

        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime Hora { get; set; }

        [Display(Name = "Nombre del empleado")]
        public string NombreEmpleado { get; set; }

        [Display(Name = "Forma de comunicacion")]
        public int FormaDeComunicacionId { get; set; }

        //[Display(Name = "Forma de comunicacion")]
        public ICollection<FormaDeComunicacion> FormaDeComunicacion { get; set; }

        public string Tema { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = "Codigos tareas")]
        public int? CodigoTareaId { get; set; }

        public virtual ICollection<CodigoTarea> Codigo { get; set; }

        [Display(Name = "Duración del llamado")]
        public string TiempoEnLlamado { get; set; }

        [Display(Name = "Tiempo post llamado")]

        public string TiempoPostLlamado { get; set; }

        public string Usuario { get; set; }

        [Display(Name = "Estado de la llamada")]
        public int? EstadoId { get; set; }

        public Estado Estado { get; set; }

        [Display(Name = "Seleccione la prioridad")]
        public int? EtiquetaId { get; set; }

        public Etiqueta Etiqueta { get; set; }

        public int Activo { get; set; }
        public int? Inicial { get; set; }
        public int? Cerrado { get; set; }
    }
}