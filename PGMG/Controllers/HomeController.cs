using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PGMG.Models;

namespace PGMG.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajustes()
        {
            return View();
        }

        public ActionResult Alerta()
        {
            return View();
        }

        public ActionResult Alertas(LlamadaSolicitadaViewModel llamadaSolicitadaView, Llamada llamada)
        {
            if (User.IsInRole("Telefonista")){

                var user = HttpContext.User.Identity.Name;

                var query = (from l in db.LlamadasSolicitadas
                             join e in db.EstadosLlamadas on l.EstadoLlamadaId equals e.EstadoLlamadaId
                             where l.EstadoLlamadaId == 1
                             && l.UsuarioTelef == user
                             && l.Respuesta == false
                             orderby l.Fecha descending
                             select new LlamadaSolicitadaViewModel
                             {
                                 Fecha = l.Fecha,
                                 Hora = l.Hora,
                                 Telefono = l.Telefono,
                                 EstadoLlamada = e.Descripcion,
                                 Observaciones = l.Observaciones,
                                 NombreCliente = l.NombreCliente,
                                 NombreEmpleado = l.NombreEmpleado,
                                 Usuario = l.Usuario,
                                 UsuarioTelef = l.UsuarioTelef,
                                 LlamadaSolicitadaId = l.LlamadaSolicitadaId,
                                 LlamadaId = l.LlamadaId.Value
                             }).ToList();

                if (query.Count() > 0)
                {
                    return View(query);
                }
                else
                {
                    return RedirectToAction("Alerta");
                }
            }
            else
            { 
                var user = HttpContext.User.Identity.Name;

                var query = (from l in db.LlamadasSolicitadas
                             join e in db.EstadosLlamadas on l.EstadoLlamadaId equals e.EstadoLlamadaId
                                 where l.Respuesta == true
                                 && l.EstadoLlamadaId != 1 
                                 && l.Usuario == user
                                 && l.Activo == false 
                                orderby l.Fecha descending
                                 select new LlamadaSolicitadaViewModel
                                 {
                                     Fecha = l.Fecha,
                                     Hora = l.Hora,
                                     Telefono = l.Telefono,
                                     EstadoLlamada = e.Descripcion,
                                     Observaciones = l.Observaciones,
                                     NombreCliente = l.NombreCliente,
                                     NombreEmpleado = l.NombreEmpleado,
                                     Usuario = l.Usuario,
                                     UsuarioTelef = l.UsuarioTelef,
                                     LlamadaSolicitadaId = l.LlamadaSolicitadaId,
                                     LlamadaId = l.LlamadaId.Value
                                 }).ToList();

                if (query.Count() > 0)
                {
                    return View(query);
                }
                else
                {
                    return RedirectToAction("Alerta");
                }

            }
        }
    }
}