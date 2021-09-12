using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PGMG.Models
{
    public class Etiqueta
    {
        public int EtiquetaId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }

}