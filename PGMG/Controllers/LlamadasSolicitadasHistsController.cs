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
    public class LlamadasSolicitadasHistsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LlamadasSolicitadasHists
        public ActionResult Index()
        {
            return View(db.LlamadasSolicitadasHists.ToList());
        }

        // GET: LlamadasSolicitadasHists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadasSolicitadasHist llamadasSolicitadasHist = db.LlamadasSolicitadasHists.Find(id);
            if (llamadasSolicitadasHist == null)
            {
                return HttpNotFound();
            }
            return View(llamadasSolicitadasHist);
        }

        // GET: LlamadasSolicitadasHists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LlamadasSolicitadasHists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LlamadasSolicitadasHistId,LlamadaSolicitadaId,ClienteId,NombreCliente,Fecha,Hora,NombreEmpleado,Usuario,EstadoLlamadaId,EstadoLlamada,Telefono,Observaciones")] LlamadasSolicitadasHist llamadasSolicitadasHist)
        {
            if (ModelState.IsValid)
            {
                db.LlamadasSolicitadasHists.Add(llamadasSolicitadasHist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(llamadasSolicitadasHist);
        }

        // GET: LlamadasSolicitadasHists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadasSolicitadasHist llamadasSolicitadasHist = db.LlamadasSolicitadasHists.Find(id);
            if (llamadasSolicitadasHist == null)
            {
                return HttpNotFound();
            }
      
            return View(llamadasSolicitadasHist);
        }

        // POST: LlamadasSolicitadasHists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LlamadasSolicitadasHistId,LlamadaSolicitadaId,ClienteId,NombreCliente,Fecha,Hora,NombreEmpleado,Usuario,EstadoLlamadaId,EstadoLlamada,Telefono,Observaciones")] LlamadasSolicitadasHist llamadasSolicitadasHist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llamadasSolicitadasHist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(llamadasSolicitadasHist);
        }

        // GET: LlamadasSolicitadasHists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlamadasSolicitadasHist llamadasSolicitadasHist = db.LlamadasSolicitadasHists.Find(id);
            if (llamadasSolicitadasHist == null)
            {
                return HttpNotFound();
            }
            return View(llamadasSolicitadasHist);
        }

        // POST: LlamadasSolicitadasHists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LlamadasSolicitadasHist llamadasSolicitadasHist = db.LlamadasSolicitadasHists.Find(id);
            db.LlamadasSolicitadasHists.Remove(llamadasSolicitadasHist);
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
