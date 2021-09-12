using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MvcValidationExtensions.Attribute;

namespace PGMG.Models
{
    #region ViajesViewModel
    public class ViajesViewModel
    {
        public int ViajesViewModelId { get; set; }

        [Display(Name = "Título")]
        public string Title { get; set; }

        [Display(Name = "Comienza")]
        public DateTime Start { get; set; }

        [Display(Name = "Finaliza")]
        public DateTime End { get; set; }

        public string Observaciones { get; set; }
        public string Confirmado { get; set; }
        public string Realizado { get; set; }
        public string Usuario { get; set; }
        public int ClienteId { get; set; }
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }

        //public bool AllDay { get; set; }
        //public string Color { get; set; }
        //public string TextColor { get; set; }
    } 
    #endregion
}