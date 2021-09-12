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
    public class EtiquetasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Etiquetas
        public ActionResult Index()
        {
            return View(db.Etiquetas.ToList());
        }

        // GET: Etiquetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiquetas.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Etiquetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EtiquetaId,Descripcion")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Etiquetas.Add(etiqueta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etiqueta);
        }

        // GET: Etiquetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiquetas.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return PartialView(etiqueta);
        }

        // POST: Etiquetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EtiquetaId,Descripcion")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiqueta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiquetas.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return PartialView(etiqueta);
        }

        // POST: Etiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiqueta etiqueta = db.Etiquetas.Find(id);
            db.Etiquetas.Remove(etiqueta);
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
