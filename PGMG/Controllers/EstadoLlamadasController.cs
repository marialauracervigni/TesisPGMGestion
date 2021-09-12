using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PGMG.Models;

namespace PGMG.Controllers
{
    [Authorize(Roles = "Administradora")]
    public class EstadoLlamadasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EstadoLlamadas
        public ActionResult Index()
        {
            return View(db.EstadosLlamadas.ToList());
        }

        // GET: EstadoLlamadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLlamada estadoLlamada = db.EstadosLlamadas.Find(id);
            if (estadoLlamada == null)
            {
                return HttpNotFound();
            }
            return View(estadoLlamada);
        }

        // GET: EstadoLlamadas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: EstadoLlamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoLlamadaId,Descripcion")] EstadoLlamada estadoLlamada)
        {
            if (ModelState.IsValid)
            {
                db.EstadosLlamadas.Add(estadoLlamada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoLlamada);
        }

        // GET: EstadoLlamadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLlamada estadoLlamada = db.EstadosLlamadas.Find(id);
            if (estadoLlamada == null)
            {
                return HttpNotFound();
            }
            return PartialView(estadoLlamada);
        }

        // POST: EstadoLlamadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoLlamadaId,Descripcion")] EstadoLlamada estadoLlamada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoLlamada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoLlamada);
        }

        // GET: EstadoLlamadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoLlamada estadoLlamada = db.EstadosLlamadas.Find(id);
            if (estadoLlamada == null)
            {
                return HttpNotFound();
            }
            return PartialView(estadoLlamada);
        }

        // POST: EstadoLlamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoLlamada estadoLlamada = db.EstadosLlamadas.Find(id);
            db.EstadosLlamadas.Remove(estadoLlamada);
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
    }
}
