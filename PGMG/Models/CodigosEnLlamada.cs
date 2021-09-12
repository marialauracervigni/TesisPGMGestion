using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGMG.Models
{
    public class CodigosEnLlamada
    {
        public int CodigosEnLlamadaId { get; set; }
        public Llamada Llamada { get; set; }
        public int LlamadaId { get; set; }

        public CodigoTarea CodigoTarea { get; set; }
        public int CodigoTareaId { get; set; }

        public int Seleccionado { get; set; }
  
    }

    public class CodigosEnLlamadaModel
    {
        public List<CodigosEnLlamada> CodigosEnLlamadas { get; set; }
    }
}