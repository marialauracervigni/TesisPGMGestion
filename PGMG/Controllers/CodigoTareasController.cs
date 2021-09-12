using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PGMG.Models;
using PagedList;

namespace PGMG.Controllers
{
    [Authorize(Roles = "Administradora, Consultora")]
    public class CodigoTareasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CodigoTareas
        public ActionResult Index()
        {
            return View(db.CodigosTareas.ToList());
        }

        // GET: CodigoTareas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoTarea codigoTarea = db.CodigosTareas.Find(id);
            if (codigoTarea == null)
            {
                return HttpNotFound();
            }
            return View(codigoTarea);
        }

        // GET: CodigoTareas/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: CodigoTareas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoTareaId,Codigo,Descripcion")] CodigoTarea codigoTarea)
        {
            if (ModelState.IsValid)
            {
                db.CodigosTareas.Add(codigoTarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(codigoTarea);
        }

        // GET: CodigoTareas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoTarea codigoTarea = db.CodigosTareas.Find(id);
            if (codigoTarea == null)
            {
                return HttpNotFound();
            }
            return PartialView(codigoTarea);
        }

        // POST: CodigoTareas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoTareaId,Codigo,Descripcion")] CodigoTarea codigoTarea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(codigoTarea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(codigoTarea);
        }

        // GET: CodigoTareas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoTarea codigoTarea = db.CodigosTareas.Find(id);
            if (codigoTarea == null)
            {
                return HttpNotFound();
            }
            return PartialView(codigoTarea);
        }

        // POST: CodigoTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CodigoTarea codigoTarea = db.CodigosTareas.Find(id);
            db.CodigosTareas.Remove(codigoTarea);
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
