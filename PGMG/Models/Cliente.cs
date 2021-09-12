using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    public class Cliente

    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }

        //public int EmpleadoId { get; set; }
   
        [Required(ErrorMessage = "Debe ingresar una localidad")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una provincia")]
        [Display(Name = "Provincia")]
        public int ProvinciaId { get; set; }

        public Provincia Provincia { get; set; }

        [Required(ErrorMessage = "Debe ingresar un teléfono")]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        public string Domicilio { get; set; }

        public string Correo { get; set; }

        [Display(Name = "Fecha Fundación")]
        public DateTime FechaFundacion { get; set; }

        [Display(Name = "Fecha Alta")]
        public DateTime FechaAlta { get; set; }

    }

}
