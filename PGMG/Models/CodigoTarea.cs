using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class CodigoTarea
    {
        public int CodigoTareaId { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public bool Seleccionado { get; set; }
        
    }

    public class CodigoTareaModel
    {
        public List<CodigoTarea> CodigosTareas { get; set; }
    }
}   