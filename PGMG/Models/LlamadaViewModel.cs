using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{

    public class LlamadaViewModel
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
        public int Activo { get; set; }
        public string Estado { get; set; }
        public string Etiqueta { get; set; }
        public int EtiquetaId { get; set; }
        public int Cantidad { get; set; }
        public int Tiempo { get; set; }
        public int CodigoTareaId { get; set; }
        public string CodigoT { get; set; }
    }
}
