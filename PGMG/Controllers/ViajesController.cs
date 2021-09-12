using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using PGMG.Models;
using PagedList;

namespace PGMG.Controllers
{
    [Authorize]
    public class ViajesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

      
        // GET: Viajes
        public ActionResult Index()
        {
            return View(db.Viajes.ToList());                
        }

        public ActionResult BuscarViajes(int? pageSize, int? page)
        {

            var query = (from cl in db.Clientes
                         join p in db.Provincias on cl.ProvinciaId equals p.ProvinciaId
                         orderby cl.Nombre ascending
                         select new ClientesBusqueda
                         {
                             ClienteId = cl.ClienteId,
                             Nombre = cl.Nombre,
                             Domicilio = cl.Domicilio,
                             Localidad = cl.Localidad,
                             Provincia = p.NombreP,
                             Telefono = cl.Telefono,
                             Correo = cl.Correo,
                             FechaAlta = cl.FechaAlta,
                             FechaFundacion = cl.FechaFundacion
                         }).ToList();

            pageSize = (pageSize ?? 200);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        public ActionResult ReporteViajes(int? id, int? pageSize, int? page, Viajes viajes)
        {
            var query = (from v in db.Viajes
                         where v.ClienteId == id
                         orderby v.FechaDesde descending
                         select new ViajesViewModel
                         {
                             ViajesViewModelId = v.ViajesId,
                             Start = v.FechaDesde,
                             End = v.FechaHasta,
                             Title = v.NombreCliente,
                             Observaciones = v.Observaciones,
                             Usuario = v.Usuario,
                             Confirmado = v.Confirmado.ToString(),
                             Realizado = v.Realizado.ToString()
                         }).ToList();

            pageSize = (pageSize ?? 50);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        // GET: Viajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            return PartialView(viajes);
        }

        
        // GET: Viajes/Create
        public ActionResult Create()
        {
            
            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            return View();
        }

        // POST: Viajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                db.Viajes.Add(viajes);
                db.SaveChanges();
                return RedirectToAction("Viaje");
                
            }

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            return View(viajes);
        }


        // GET: Viajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            return View(viajes);
        }

        // POST: Viajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Viajes viajes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Viaje");
            }
            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;
            return View(viajes);
        }

        // GET: Viajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajes viajes = db.Viajes.Find(id);
            if (viajes == null)
            {
                return HttpNotFound();
            }
            return PartialView(viajes);
        }

        // POST: Viajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajes viajes = db.Viajes.Find(id);
            db.Viajes.Remove(viajes);
            db.SaveChanges();
            return RedirectToAction("Viaje");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Viaje()
        {
            var query = (from l in db.Viajes        
                         select new ViajesViewModel
                         {
                             ViajesViewModelId = l.ViajesId,
                             Start = l.FechaDesde,
                             End = l.FechaHasta,
                             Title = l.NombreCliente,
                             Observaciones = l.Observaciones
                         }).ToList();
            return View(query);
        }

        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var events = from v in db.Viajes
                         where v.FechaDesde > start && v.FechaHasta < end
                         select v;

            List<Events> eventos = new List<Events>();
            foreach (var item in events)
            {
                Events evento = new Events();
                evento.id = item.ViajesId;
                evento.start = item.FechaDesde;
                evento.end = item.FechaHasta;
                evento.title = item.Usuario + " - " + item.NombreCliente + " " + item.Observaciones;
                
                eventos.Add(evento);
            }
            return Json(eventos, JsonRequestBehavior.AllowGet);
        }
    }
}
