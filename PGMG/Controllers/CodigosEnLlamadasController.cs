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
    public class CodigosEnLlamadasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CodigosEnLlamadas
        public ActionResult Index()
        {
            var codigosEnLlamadas = db.CodigosEnLlamadas.Include(c => c.CodigoTarea).Include(c => c.Llamada);
            return View(codigosEnLlamadas.ToList());
        }

        // GET: CodigosEnLlamadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigosEnLlamada codigosEnLlamada = db.CodigosEnLlamadas.Find(id);
            if (codigosEnLlamada == null)
            {
                return HttpNotFound();
            }
            return View(codigosEnLlamada);
        }

        // GET: CodigosEnLlamadas/Create
        public ActionResult Create()
        {
            ViewBag.CodigoTareaId = new SelectList(db.CodigosTareas, "CodigoTareaId", "Descripcion");
            ViewBag.LlamadaId = new SelectList(db.Llamadas, "LlamadaId", "NombreCliente");
            return View();
        }

        // POST: CodigosEnLlamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigosEnLlamadaId,LlamadaId,CodigoTareaId,Seleccionado")] CodigosEnLlamada codigosEnLlamada)
        {
            if (ModelState.IsValid)
            {
                db.CodigosEnLlamadas.Add(codigosEnLlamada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoTareaId = new SelectList(db.CodigosTareas, "CodigoTareaId", "Descripcion", codigosEnLlamada.CodigoTareaId);
            ViewBag.LlamadaId = new SelectList(db.Llamadas, "LlamadaId", "NombreCliente", codigosEnLlamada.LlamadaId);
            return View(codigosEnLlamada);
        }

        // GET: CodigosEnLlamadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigosEnLlamada codigosEnLlamada = db.CodigosEnLlamadas.Find(id);
            if (codigosEnLlamada == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoTareaId = new SelectList(db.CodigosTareas, "CodigoTareaId", "Descripcion", codigosEnLlamada.CodigoTareaId);
            ViewBag.LlamadaId = new SelectList(db.Llamadas, "LlamadaId", "NombreCliente", codigosEnLlamada.LlamadaId);
            return View(codigosEnLlamada);
        }

        // POST: CodigosEnLlamadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigosEnLlamadaId,LlamadaId,CodigoTareaId,Seleccionado")] CodigosEnLlamada codigosEnLlamada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codigosEnLlamada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoTareaId = new SelectList(db.CodigosTareas, "CodigoTareaId", "Descripcion", codigosEnLlamada.CodigoTareaId);
            ViewBag.LlamadaId = new SelectList(db.Llamadas, "LlamadaId", "NombreCliente", codigosEnLlamada.LlamadaId);
            return View(codigosEnLlamada);
        }

        // GET: CodigosEnLlamadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigosEnLlamada codigosEnLlamada = db.CodigosEnLlamadas.Find(id);
            if (codigosEnLlamada == null)
            {
                return HttpNotFound();
            }
            return View(codigosEnLlamada);
        }

        // POST: CodigosEnLlamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodigosEnLlamada codigosEnLlamada = db.CodigosEnLlamadas.Find(id);
            db.CodigosEnLlamadas.Remove(codigosEnLlamada);
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
