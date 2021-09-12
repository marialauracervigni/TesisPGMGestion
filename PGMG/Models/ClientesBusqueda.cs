using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class ClientesBusqueda
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        //public int EmpleadoId { get; set; }
        public string Empleados { get; set; }

        public string Localidad { get; set; }

        [Display(Name = "Provincia")]
        public int ProvinciaId { get; set; }
  
        public string Provincia { get; set; }

        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        public string Domicilio { get; set; }

        public string Correo { get; set; }

        
        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; }

        
        [Display(Name = "Fecha Fundación")]
        public DateTime FechaFundacion { get; set; }
        public string Modulos { get; set; }
    }
}