using System;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class PendientesViewModel
    {
        public int LlamadaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Usuario { get; set; }
        [Display(Name = "Cliente")]
        public string NombreC { get; set; }
        [Display(Name = "Empleado")]
        public string NombreE { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public string Etiqueta { get; set; }
        public int EtiquetaId { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Duración del llamado")]
        public string TiempoEnLlamado { get; set; }
        [Display(Name = "Tiempo de gestión")]
        public string TiempoPostLlamado { get; set; }
        public string NombreBuscar { get; set; }
    }
}