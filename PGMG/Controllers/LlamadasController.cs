using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PGMG.Models;
using PagedList;
using System.Collections.Generic;

namespace PGMG.Controllers
{
    public class LlamadasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Llamadas
        //Index de Llamadas en Curso
        public ActionResult Index(int? pageSize, int? page)
        {
            Llamada llamada = new Llamada();

            var query = (from l in db.Llamadas where l.Activo == 1
                         orderby l.Fecha descending
                         select new LlamadaViewModel
                                   {
                                    Fecha = l.Fecha,
                                    Hora = l.Hora,
                                    Usuario = l.Usuario,
                                    NombreC = l.NombreCliente,
                                    NombreE = l.NombreEmpleado
                                   }).ToList();

            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }
        
        //Index de llamadas del día
        public ActionResult Index2(int? pageSize, int? page)
        { 
            var query = (from l in db.Llamadas
                         where DbFunctions.TruncateTime(l.Fecha) == DateTime.Today
                         orderby l.Hora descending
                         select new LlamadaViewModel
                         {
                             LlamadaId = l.LlamadaId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             Usuario = l.Usuario,
                             NombreC = l.NombreCliente,
                             NombreE = l.NombreEmpleado,
                             Tema = l.Tema
                         }).ToList();

            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        //Index de pendientes
        [Authorize(Roles = "Administradora, Consultora")]
        public ActionResult IndexPendientes(int? pageSize, int? page)
        {
            Llamada llamada = new Llamada();

            var query = (from l in db.Llamadas
                         where l.EstadoId == 2
                         orderby l.Fecha descending

                         select new PendientesViewModel
                         {
                             LlamadaId = l.LlamadaId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             Usuario = l.Usuario,
                             NombreC = l.NombreCliente,
                             Tema = l.Tema,
                             Etiqueta = l.Etiqueta.Descripcion
                         }).ToList();

            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        [Authorize(Roles = "Administradora, Consultora")]
        //Ultimas llamadas por cliente
        public ActionResult UltimasLlamadas(int? id, Llamada llamada)
        {
            var query = (from l in db.Llamadas
                         where l.Activo == 0
                         && l.ClienteId == id
                         && l.LlamadaId != llamada.LlamadaId

                         orderby l.Fecha descending
                         select new LlamadaViewModel
                         {
                             LlamadaId = l.LlamadaId,
                             ClienteId = l.ClienteId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             Usuario = l.Usuario,
                             NombreE = l.NombreEmpleado,
                             Tema = l.Tema,
                             Descripcion = l.Descripcion
                         }).Take(5);

            return PartialView(query);
        }

        public ActionResult ReporteLlamadas(int? id, int? pageSize, int? page, Llamada llamada)
        {
            var query = (from l in db.Llamadas
                         where  l.ClienteId == id
                         && l.LlamadaId != llamada.LlamadaId
                         && l.Activo == 0
                         && l.EstadoId == 1
                         orderby l.Fecha descending
                         select new LlamadaViewModel
                         {
                             LlamadaId = l.LlamadaId,
                             ClienteId = l.ClienteId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             Tema = l.Tema,
                             Descripcion = l.Descripcion,
                             Usuario = l.Usuario,
                             NombreE = l.NombreEmpleado,
                             Estado = l.Estado.Descripcion,
                             Etiqueta = l.Etiqueta.Descripcion                
                         }).ToList();

            pageSize = (pageSize ?? 50);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        public ActionResult ReportePendientes(int? id, int? pageSize, int? page, Llamada llamada)
        {
            var query = (from l in db.Llamadas
                         where l.ClienteId == id
                         && l.LlamadaId != llamada.LlamadaId
                         && l.Activo == 0
                         && l.EstadoId == 2
                         orderby l.Fecha descending
                         select new LlamadaViewModel
                         {
                             LlamadaId = l.LlamadaId,
                             ClienteId = l.ClienteId,
                             Fecha = l.Fecha,
                             Hora = l.Hora,
                             Tema = l.Tema,
                             Descripcion = l.Descripcion,
                             Usuario = l.Usuario,
                             NombreE = l.NombreEmpleado,
                             Estado = l.Estado.Descripcion,
                             Etiqueta = l.Etiqueta.Descripcion
                         }).ToList();

            pageSize = (pageSize ?? 50);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        //Historial llamada pendiente
        public ActionResult Historial(int? id, int? pageSize, int? page)
        {
  
            var query = (from h in db.LlamadasHist
                         join l in db.Llamadas on h.LlamadaId equals l.LlamadaId
                         where 
                         //l.EstadoId == 2
                        // &&
                         l.LlamadaId == id
                         orderby l.Fecha descending
                         select new PendientesViewModel
                         {
                             LlamadaId = h.LlamadaId,
                             ClienteId = h.ClienteId,
                             NombreC = h.NombreCliente,
                             TiempoPostLlamado = h.TiempoPostLlamado,
                             Fecha = h.Fecha,
                             Hora = h.Hora,
                             Tema = h.Tema,
                             Descripcion = h.Descripcion,
                             Usuario = h.Usuario,
                             NombreE = h.NombreEmpleado,
                             Estado = h.Estado.Descripcion,
                             Etiqueta = h.Etiqueta.Descripcion
                         }).ToList();

            pageSize = (pageSize ?? 20);
            page = (page ?? 1);
            ViewBag.PageSize = pageSize;
            var list = query.ToPagedList(page.Value, pageSize.Value);

            return View(list);
        }

        public ActionResult BuscarLlamadas(int? pageSize, int? page)
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

        public ActionResult BuscarTareasPendientes(int? pageSize, int? page)
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

        // GET: Llamadas/Create
        [Authorize(Roles = "Administradora, Consultora")]
        public ActionResult Create()
        {
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

             ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View();
        }

        // POST: Llamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Consultora")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Llamada llamada)
        {
            {    
                if (ModelState.IsValid)
                {
                    db.Llamadas.Add(llamada);
                    db.SaveChanges();
                    
                    //return View(llamada);
                    return RedirectToAction("Edit2"+"/"+llamada.LlamadaId);
                }

                var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
                ViewData["formadecomun"] = formadecomun;

                ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

                var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
                ViewData["usuarioactual"] = usuarioactual;

                var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
                ViewData["estado"] = estado;

                var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
                ViewData["Etiqueta"] = Etiqueta;

                return View(llamada);            
            }
        }

        [Authorize(Roles = "Administradora, Consultora")]
        // GET: Llamadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);

            if (llamada == null)
            {
                return HttpNotFound();
            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }

        // POST: Llamadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Consultora")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Llamada llamada, LlamadaHist llamadaHist, int?[] CodigoTareaId, CodigosEnLlamada codigosEnLlamada)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in CodigoTareaId)
                {
                    db.CodigosEnLlamadas.Add(new CodigosEnLlamada { LlamadaId = llamada.LlamadaId, CodigoTareaId = item.Value });
                    db.SaveChanges();
                }

                db.Entry(llamada).State = EntityState.Modified;
                db.Entry(llamadaHist).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index2");
            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }


        [Authorize(Roles = "Administradora, Consultora")]
        // GET: Cargar llamada
        public ActionResult Edit2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);
            LlamadaSolicitada llamadaSolicitada = db.LlamadasSolicitadas.Find(id);

            if (llamada == null)
            {
                return HttpNotFound();
            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");


            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }

        // POST: Cargar llamada
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Consultora")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2(Llamada llamada, LlamadaHist llamadaHist, int?[] CodigoTareaId, CodigosEnLlamada codigosEnLlamada)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in CodigoTareaId)
                {
                    db.CodigosEnLlamadas.Add(new CodigosEnLlamada { LlamadaId = llamada.LlamadaId, CodigoTareaId = item.Value });
                    db.SaveChanges();
                }
                //Si la llamada se guarda como tarea pendiente, inserto la marca de inicio
                if (llamada.EstadoId == 2)
                {
                    llamadaHist.Inicial = 1;
                }

                db.Entry(llamada).State = EntityState.Modified;
                llamadaHist.Inicial = 1;
                db.Entry(llamadaHist).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index2");

            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }


        // GET: Llamadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);

            if (llamada == null)
            {
                return HttpNotFound();
            }
            return View(llamada);
        }

        [Authorize(Roles = "Administradora, Consultora")]
        // GET: Llamadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);
            if (llamada == null)
            {
                return HttpNotFound();
            }
            return PartialView(llamada);
        }

        [Authorize(Roles = "Administradora, Consultora")]
        // POST: Llamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Llamada llamada = db.Llamadas.Find(id);
            db.Llamadas.Remove(llamada);
            db.SaveChanges();
            return RedirectToAction("Index2");
        }

        [Authorize(Roles = "Administradora, Consultora")]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [Authorize(Roles = "Administradora, Consultora")]
        public ActionResult CrearLlamadasPendientes()
        {
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion", 2);
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View();
        }

        // POST: Llamadas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Consultora")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearLlamadasPendientes(Llamada llamada, LlamadaHist llamadaHist, int?[] CodigoTareaId, CodigosEnLlamada codigosEnLlamada)
        { 
            if (ModelState.IsValid)
            {
               
                db.Llamadas.Add(llamada);
                db.SaveChanges();
                foreach (var item in CodigoTareaId)
                {
                    db.CodigosEnLlamadas.Add(new CodigosEnLlamada { LlamadaId = llamada.LlamadaId, CodigoTareaId = item.Value });
                    db.SaveChanges();
                }


                //Inicial en 1 marca que es el momento en el que nace la tarea pendiente.
                llamadaHist.Inicial = 1;
                llamadaHist.LlamadaId = llamada.LlamadaId;
                db.LlamadasHist.Add(llamadaHist);
                db.SaveChanges();
                return RedirectToAction("IndexPendientes");
            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", User.Identity.Name);
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion", 2);
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }

        // GET: Llamadas/Edit/5
        [Authorize(Roles = "Administradora, Consultora")]
        public ActionResult GestionarLlamadasPendientes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);

            CodigosEnLlamada codigosEnLlamada = db.CodigosEnLlamadas.Find(id);

            if (llamada == null)
            {
                return HttpNotFound();
            }

            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;

            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }

        // POST: Llamadas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administradora, Consultora")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GestionarLlamadasPendientes(Llamada llamada, LlamadaHist llamadaHist, int?[] CodigoTareaId, CodigosEnLlamada codigosEnLlamada)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in CodigoTareaId)
                {
                    db.CodigosEnLlamadas.Add(new CodigosEnLlamada { LlamadaId = llamada.LlamadaId, CodigoTareaId = item.Value });
                    db.SaveChanges();
                }
                //Si la llamada se marca como finalizada, inserto un 1 en cerrado.
                if (llamada.EstadoId == 1)
                {
                    llamadaHist.Cerrado = 1;
                }
                db.Entry(llamadaHist).State = EntityState.Added;
                db.Entry(llamada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPendientes");
            }
            var formadecomun = new SelectList(db.FormasDeComunicacion.ToList(), "FormaDeComunicacionId", "Detalle");
            ViewData["formadecomun"] = formadecomun;

            ViewBag.codTarea = new SelectList(db.CodigosTareas.ToList(), "CodigoTareaId", "Descripcion");

            var usuarioactual = new SelectList(db.Users.ToList(), "UserName", "NombreCompleto", "User.Identity.GetUserId()");
            ViewData["usuarioactual"] = usuarioactual;


            var estado = new SelectList(db.Estados.ToList(), "EstadoId", "Descripcion");
            ViewData["estado"] = estado;

            var Etiqueta = new SelectList(db.Etiquetas.ToList(), "EtiquetaId", "Descripcion");
            ViewData["Etiqueta"] = Etiqueta;

            return View(llamada);
        }

        [Authorize(Roles = "Administradora, Consultora")]
        // LlamadasPendientes
        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llamada llamada = db.Llamadas.Find(id);

            if (llamada == null)
            {
                return HttpNotFound();
            }
            return View(llamada);
        }

    }
}
