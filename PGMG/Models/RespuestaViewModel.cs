using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGMG.Models
{
    public class RespuestaViewModel
    {
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; }
    }
}