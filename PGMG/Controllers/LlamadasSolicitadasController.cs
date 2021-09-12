using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PGMG.Models;
using PagedList;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using PGMG.Migrations;

namespace PGMG.Controllers
{
    public class LlamadasSolicitadasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LlamadasSolicitadas
        //Llamadas solicitadas y pendientes
        public ActionResult Index(int? pageSize, int? page)
        {
            LlamadaSolicitada llamadaSolicitada = new LlamadaSolicitada();

            var query = (from l in db.LlamadasSolicitadas
                         join e in db.EstadosLlamadas on l.EstadoLlamadaId equals e.EstadoLlamadaId
                         where l.EstadoLlamadaId == 1
                         select new LlamadaSolicitadaViewModel
                         {
                             LlamadaSolicitadaId = l.LlamadaSolicitadaId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             NombreCliente = l.NombreCliente,
                             NombreEmpleado = l.NombreEmpleado,
                             Observaciones = l.Observaciones,
                             Telefono = l.Telefono.ToString(),
                             Usuario = l.Usuario,
                             UsuarioTelef = l.UsuarioTelef,
                             EstadoLlamada = e.Descripcion

                         }).ToList();
            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);

        }

        //Llamadas del día
        [Authorize(Roles = "Administradora, Telefonista")]
        public ActionResult Index2(int? pageSize, int? page)
        {
            LlamadaSolicitada llamadaSolicitada = new LlamadaSolicitada();

            var query = (from l in db.LlamadasSolicitadas
                         join e in db.EstadosLlamadas on l.EstadoLlamadaId equals e.EstadoLlamadaId
                         where DbFunctions.TruncateTime(l.Fecha) == DateTime.Today
                         where l.EstadoLlamadaId != 1
                         select new LlamadaSolicitadaViewModel
                         {
                             LlamadaSolicitadaId = l.LlamadaSolicitadaId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             NombreCliente = l.NombreCliente,
                             NombreEmpleado = l.NombreEmpleado,
                             Observaciones = l.Observaciones,
                             Telefono = l.Telefono.ToString(),
                             Usuario = l.Usuario,
                             UsuarioTelef = l.UsuarioTelef,
                             EstadoLlamada = e.Descripcion

                         }).ToList();
            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }


        public ActionResult Historial(int? id)
        {
            var query = (from h in db.LlamadasSolicitadasHists
                         join l in db.LlamadasSolicitadas on h.LlamadaSolicitadaId equals l.LlamadaSolicitadaId
                         where l.LlamadaSolicitadaId == id
                         orderby l.Fecha descending
                         select new LlamadaSolicitadaViewModel
                         {
                             LlamadaSolicitadaId = h.LlamadaSolicitadaId,
                             Fecha = h.Fecha,
                             Hora = h.Hora,
                             NombreCliente = h.NombreCliente,
                             NombreEmpleado = h.NombreEmpleado,
                             Usuario = h.Usuario,
                             Telefono = h.Telefono,
                             Observaciones = h.Observaciones,
                             EstadoLlamada = h.EstadoLlamada,
                             UsuarioTelef = h.UsuarioTelef,
                             EstadoLlamadaId = h.EstadoLlamadaId,
                             LlamadaId = h.LlamadaId,
                             Respuesta = h.Respuesta

                         }).ToList();

            return View(query);
        }

        // GET: LlamadasSolicitadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            if (llamadaSolicitada == null)
            {
                return HttpNotFound();
            }
            return View(llamadaSolicitada);
        }


        [Authorize(Roles = "Administradora, Consultora")]
        // GET: LlamadasSolicitadas/Create
        public ActionResult Create()
        {
            var estado = new SelectList(db.EstadosLlamadas.ToList(), "EstadoLlamadaId", "Descripcion");
            ViewData["estado"] = estado;

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            var usuariotel = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuariotel"] = usuariotel;

            return View();
        }


        [Authorize(Roles = "Administradora, Consultora")]
        // POST: LlamadasSolicitadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LlamadaSolicitada llamadaSolicitada, LlamadasSolicitadasHist llamadasSolicitadasHist)
        {

            if (ModelState.IsValid)
            {
                db.LlamadasSolicitadas.Add(llamadaSolicitada);
                db.LlamadasSolicitadasHists.Add(llamadasSolicitadasHist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var estado = new SelectList(db.EstadosLlamadas.ToList(), "EstadoLlamadaId", "Descripcion");
            ViewData["estado"] = estado;


            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            var usuariotel = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuariotel"] = usuariotel;

            return View(llamadaSolicitada);
        }

        [Authorize(Roles = "Administradora, Telefonista")]
        // GET: LlamadasSolicitadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);

            if (llamadaSolicitada == null)
            {
                return HttpNotFound();
            }
            var estado = new SelectList(db.EstadosLlamadas.ToList(), "EstadoLlamadaId", "Descripcion");
            ViewData["estado"] = estado;

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuarioactual"] = usuarioactual;

            var usuariotel = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuariotel"] = usuariotel;


            return View(llamadaSolicitada);
        }


        // POST: LlamadasSolicitadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Telefonista")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LlamadaSolicitada llamadaSolicitada, Llamada llamada, LlamadasSolicitadasHist llamadasSolicitadasHist)
        {       
                if (ModelState.IsValid)
                {
                db.Entry(llamadaSolicitada).State = EntityState.Modified;

                if (llamadaSolicitada.EstadoLlamadaId == 2)
                {
                    db.Llamadas.Add(llamada);
                    llamadaSolicitada.Respuesta = true;
                    db.SaveChanges();
                    llamadaSolicitada.LlamadaId = llamada.LlamadaId;
                    db.LlamadasSolicitadasHists.Add(llamadasSolicitadasHist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                if (llamadaSolicitada.EstadoLlamadaId == 3 || llamadaSolicitada.EstadoLlamadaId == 4)
                {
                    llamadaSolicitada.Respuesta = true;
                    llamadaSolicitada.LlamadaId = 0;
                    db.LlamadasSolicitadasHists.Add(llamadasSolicitadasHist);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            var estado = new SelectList(db.EstadosLlamadas.ToList(), "EstadoLlamadaId", "Descripcion");
            ViewData["estado"] = estado;

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuarioactual"] = usuarioactual;

            var usuariotel = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto");
            ViewData["usuariotel"] = usuariotel;

            return View(llamadaSolicitada);
        }


        [Authorize(Roles = "Administradora, Telefonista")]
        // GET: LlamadasSolicitadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            db.Entry(llamadaSolicitada).Reference("EstadLlamada").Load();
            if (llamadaSolicitada == null)
            {
                return HttpNotFound();
            }
            return View(llamadaSolicitada);
        }

        [Authorize(Roles = "Administradora, Telefonista")]
        // POST: LlamadasSolicitadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            db.LlamadasSolicitadas.Remove(llamadaSolicitada);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

 
        // GET: LlamadasSolicitadas/Delete/5
        public ActionResult Edit3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            if (llamadaSolicitada == null)
            {
                return HttpNotFound();
            }
            return PartialView(llamadaSolicitada);
        }

        // POST: LlamadasSolicitadas/Delete/5
        [HttpPost, ActionName("Edit3")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit3Confirmed(int id)
        {
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            llamadaSolicitada.Activo = true;
            db.Entry(llamadaSolicitada).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Alertas","Home");
        }

        // GET: LlamadasSolicitadas/Delete/5
        public ActionResult Edit4(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            if (llamadaSolicitada == null)
            {
                return HttpNotFound();
            }
            return PartialView(llamadaSolicitada);
        }

        // POST: LlamadasSolicitadas/Delete/5
        [HttpPost, ActionName("Edit4")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit4Confirmed(int id)
        {
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);
            llamadaSolicitada.EstadoLlamadaId = 4;
            db.Entry(llamadaSolicitada).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "LlamadasSolicitadas");
        }
    }
}



