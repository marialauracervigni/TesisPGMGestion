using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PGMG.Models;
using PagedList;
using Rotativa.MVC;

namespace PGMG.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Listado total clientes
        public ActionResult Index(int? pageSize, int? page)
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

            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        public JsonResult Lista(string term)
        {
            ClientesViewModel cliente = new ClientesViewModel();
            return Json(cliente.ClientesAutocompletar(term), JsonRequestBehavior.AllowGet);
        }


        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            db.Entry(cliente).Reference("Provincia").Load();

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            db.Entry(cliente).Reference("Provincia").Load();
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return PartialView(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);

            db.Clientes.Remove(cliente);
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


        public ActionResult Detalle()
        {
            return PartialView();
        }

        public ActionResult Create()
        {
            var prov = new SelectList(db.Provincias.ToList(), "ProvinciaId", "NombreP");
            ViewData["prov"] = prov;

            return View();
        }

        // POST: Llamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente) 
        {
            {
                if (ModelState.IsValid)
                {
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
                }
                var prov = new SelectList(db.Provincias.ToList(), "ProvinciaId", "NombreP");
                ViewData["prov"] = prov;

                return View(cliente);
            }
        }


        // GET: Modulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            var prov = new SelectList(db.Provincias.ToList(), "ProvinciaId", "NombreP");
            ViewData["prov"] = prov;

            return View(cliente);
        }

        // POST: Modulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var prov = new SelectList(db.Provincias.ToList(), "ProvinciaId", "NombreP");
            ViewData["prov"] = prov;
            return View(cliente);
        }

    }
}
