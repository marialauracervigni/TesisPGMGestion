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
    public class FormaDeComunicacionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FormaDeComunicacion
        public ActionResult Index()
        {
            return View(db.FormasDeComunicacion.ToList());
        }

        // GET: FormaDeComunicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDeComunicacion formaDeComunicacion = db.FormasDeComunicacion.Find(id);
            if (formaDeComunicacion == null)
            {
                return HttpNotFound();
            }
            return View(formaDeComunicacion);
        }

        // GET: FormaDeComunicacion/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: FormaDeComunicacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormaDeComunicacionId,Detalle")] FormaDeComunicacion formaDeComunicacion)
        {
            if (ModelState.IsValid)
            {
                db.FormasDeComunicacion.Add(formaDeComunicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaDeComunicacion);
        }

        // GET: FormaDeComunicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDeComunicacion formaDeComunicacion = db.FormasDeComunicacion.Find(id);
            if (formaDeComunicacion == null)
            {
                return HttpNotFound();
            }
            return PartialView(formaDeComunicacion);
        }

        // POST: FormaDeComunicacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormaDeComunicacionId,Detalle")] FormaDeComunicacion formaDeComunicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaDeComunicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaDeComunicacion);
        }

        // GET: FormaDeComunicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDeComunicacion formaDeComunicacion = db.FormasDeComunicacion.Find(id);
            if (formaDeComunicacion == null)
            {
                return HttpNotFound();
            }
            return PartialView(formaDeComunicacion);
        }

        // POST: FormaDeComunicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormaDeComunicacion formaDeComunicacion = db.FormasDeComunicacion.Find(id);
            db.FormasDeComunicacion.Remove(formaDeComunicacion);
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
