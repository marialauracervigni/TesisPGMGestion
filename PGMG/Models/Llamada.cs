using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class Llamada
    {
        public int LlamadaId { get; set; }
        public int? LlamadaSolicitadaId { get; set; }
        
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar un cliente")]
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime Fecha { get; set; }

       
        [Required(ErrorMessage = "Debe ingresar una hora")]
        public DateTime Hora { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del empleado")]
        [Display(Name = "Nombre del empleado")]
        public string NombreEmpleado { get; set; }


        [Display(Name = "Forma de comunicacion")]
        public int FormaDeComunicacionId { get; set; }
        
        [Display(Name = "Forma de comunicación")]
        public ICollection<FormaDeComunicacion> FormaDeComunicacion { get; set; }

        public string Tema { get; set; }

        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Display(Name = "Codigos tareas")]
        public int CodigoTareaId { get; set; }

        [Display(Name = "Códigos de tareas")]
        public virtual ICollection<CodigoTarea> Codigo { get; set; }


        [Display(Name = "Duración del llamado")]
        public string TiempoEnLlamado { get; set; }

        [Display(Name = "Tiempo de gestión")]
    
        public string  TiempoPostLlamado { get; set; }

        public string Usuario { get; set; }

        //[Display(Name = "Estado de la llamada")]
        public int? EstadoId { get; set; }


        [Display(Name = "Estado de la llamada")]
        public Estado Estado { get; set;}
   
        public int? EtiquetaId { get; set; }

        [Display(Name = "Seleccione la prioridad")]
        public Etiqueta Etiqueta { get; set; }

        public int Activo { get; set; }
    }
}