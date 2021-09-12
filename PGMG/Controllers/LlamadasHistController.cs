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
    public class LlamadasHistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LlamadasHist
        public ActionResult Index()
        {
            return View(db.LlamadasHist.ToList());
        }

        // GET: LlamadasHist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaHist llamadaHist = db.LlamadasHist.Find(id);
            if (llamadaHist == null)
            {
                return HttpNotFound();
            }
            return View(llamadaHist);
        }

        // GET: LlamadasHist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LlamadasHist/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LlamadaHist llamadaHist)
        {
            if (ModelState.IsValid)
            {
                db.LlamadasHist.Add(llamadaHist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(llamadaHist);
        }

        // GET: LlamadasHist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaHist llamadaHist = db.LlamadasHist.Find(id);
            if (llamadaHist == null)
            {
                return HttpNotFound();
            }
            return View(llamadaHist);
        }

        // POST: LlamadasHist/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LLamadaHistId,Usuario,Fecha,Descripcion,DuracionTarea")] LlamadaHist llamadaHist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llamadaHist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(llamadaHist);
        }

        // GET: LlamadasHist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadaHist llamadaHist = db.LlamadasHist.Find(id);
            if (llamadaHist == null)
            {
                return HttpNotFound();
            }
            return View(llamadaHist);
        }

        // POST: LlamadasHist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LlamadaHist llamadaHist = db.LlamadasHist.Find(id);
            db.LlamadasHist.Remove(llamadaHist);
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
