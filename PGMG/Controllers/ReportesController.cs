using PagedList;
using PGMG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Data.Entity.SqlServer;

namespace PGMG.Controllers
{
    public class ReportesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
      
        // GET: Reportes
        public ActionResult Index()
        {      
            return View();
        }


        public ActionResult Pendientes()
        {
            return View();
        }

        public ActionResult Llamadas()
        {
            return View();
        }

        public ActionResult LlamadasSolicitadas()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Llamadas(DateTime? desde, DateTime? hasta, ReporteLlamadasViewModel reporteLlamadasViewModel)
        {
            { 
            if (ModelState.IsValid)
            {
                //INICIO LLAMADAS POR FECHA
                var list1 = db.Llamadas.Where(x => x.EstadoId == 1 & x.Activo == 0 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                var ord = list1.OrderBy(x => x.Fecha);
                List<int> cantidad = new List<int>();
                var pend1 = ord.Select(x => x.Fecha).Distinct();
                var pend2 = pend1.Select(x => x.ToShortDateString());

                foreach (var item in pend1)
                {
                    cantidad.Add(ord.Count(x => x.Fecha == item));
                }

                ViewBag.LLPF = cantidad.ToList();
                ViewBag.LLPF2 = pend2.ToList();
                //FIN LLAMADAS POR FECHA


                //INICIO LLAMADAS POR FORMA DE COMUNICACIÓN
                var list3 = db.Llamadas.Where(x => x.EstadoId == 1 & x.Activo == 0 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                var list4 = list3.Join(db.FormasDeComunicacion, r => r.FormaDeComunicacionId, p => p.FormaDeComunicacionId, (r, p) => new {p.Detalle });
                var ord1 = list4.OrderBy(x => x.Detalle);
                List<int> cantidad1 = new List<int>();
                var pend3 = ord1.Select(x => x.Detalle).Distinct();
                
                foreach (var item in pend3)
                {
                    cantidad1.Add(ord1.Count(x => x.Detalle == item));
                }

                ViewBag.LLFC = cantidad1.ToList();
                ViewBag.forma = pend3;
                //FIN LLAMADAS POR FORMA DE COMUNICACIÓN


                //INICIO LLAMADAS POR MES
                var list5 = db.Llamadas.Where(x => x.EstadoId == 1 & x.Activo == 0 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                var ord2 = list5.OrderBy(x => x.Fecha);
                List<int> cantidad2 = new List<int>();
                var pend4 = ord2.Select(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))).Distinct();

                //var pend31 = pend30.GetEnumerator.dat

                foreach (var item in pend4)
                {
                    cantidad2.Add(ord2.Count(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")) == item));
                }

                ViewBag.LLPM = cantidad2.ToList();
                ViewBag.LLPM2 = pend4;
                //FIN LLAMADAS POR MES
         
                }
                return View();
            }
        }      

        [HttpPost]
        public ActionResult Pendientes(DateTime? desde, DateTime? hasta, ReporteLlamadasViewModel reporteLlamadasViewModel)
        {
            { 
                if (ModelState.IsValid)
                {
                    //INICIO TOTAL PENDIENTES
                    var list5 = db.Llamadas.Where(x => x.EstadoId == 2).ToList();
                    var list6 = list5.Join(db.Etiquetas, r => r.EtiquetaId, p => p.EtiquetaId, (r, p) => new { p.Descripcion });
                    var ord = list6.OrderBy(x => x.Descripcion);
                    List<int> cantidad5 = new List<int>();
                    var pend = ord.Select(x => x.Descripcion).Distinct();

                    foreach (var item in pend)
                    {
                        cantidad5.Add(ord.Count(x => x.Descripcion == item));
                    }

                    ViewBag.TP = cantidad5.ToList();
                    ViewBag.TP2 = pend.ToList();
                    //FIN TOTAL PENDIENTES

                    //INICIO PENDIENTES POR FECHA INGRESADA
                    var list7 = db.LlamadasHist.Where(x => x.EstadoId == 2 & x.Activo == 0 & x.Inicial == 1 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var list8 = list7.Join(db.Etiquetas, r => r.EtiquetaId, p => p.EtiquetaId, (r, p) => new { p.Descripcion });
                    var list9 = list8.OrderBy(x => x.Descripcion).ToList();
                    List<int> cantidad1 = new List<int>();
                    var pend1 = list9.Select(x => x.Descripcion).Distinct();

                    foreach (var item in pend1)
                    {
                        cantidad1.Add(list9.Count(x => x.Descripcion == item));
                    }

                    ViewBag.PPS = cantidad1.ToList();
                    ViewBag.PPS2 = pend1.ToList();
                    //FIN PENDIENTES POR FECHA INGRESADA

                    //INICIO PENDIENTES CERRADOS POR FECHA INGRESADA
                    var list10 = db.LlamadasHist.Where(x => x.Cerrado == 1 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var list11 = list10.Join(db.Etiquetas, r => r.EtiquetaId, p => p.EtiquetaId, (r, p) => new { p.Descripcion });
                    var list12 = list11.OrderBy(x => x.Descripcion).ToList();
                    List<int> cantidad2 = new List<int>();
                    var pend2 = list12.Select(x => x.Descripcion).Distinct();

                    foreach (var item in pend2)
                    {
                        cantidad2.Add(list12.Count(x => x.Descripcion == item));
                    }

                    ViewBag.PCF = cantidad2.ToList();
                    ViewBag.PCF2 = pend2.ToList();
                    //FIN PENDIENTES CERRADOS POR FECHA INGRESADA

                    //INICIO PENDIENTES POR MES
                    var list13 = db.LlamadasHist.Where(x => x.EstadoId == 2 & x.Activo == 0 & x.Inicial == 1 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var list14 = list13.OrderBy(x => x.Fecha);
                    List<int> cantidad3 = new List<int>();
                    var pend3 = list14.Select(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))).Distinct();

                    //var pend31 = pend30.GetEnumerator.dat

                    foreach (var item in pend3)
                    {
                        cantidad3.Add(list14.Count(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")) == item));
                    }

                    ViewBag.PPM = cantidad3.ToList();
                    ViewBag.PPM2 = pend3;
                    //FIN PENDIENTES POR MES

                    //INICIO PENDIENTES POR FECHA
                    var list15 = db.LlamadasHist.Where(x => x.EstadoId == 2 & x.Activo == 0 & x.Inicial == 1 & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var list16 = list15.OrderBy(x => x.Fecha);
                    List<int> cantidad4 = new List<int>();
                    var pend4 = list16.Select(x => x.Fecha).Distinct();
                    var pend5 = pend4.Select(x => x.ToShortDateString());

                    foreach (var item in pend4)
                    {
                        cantidad4.Add(list16.Count(x => x.Fecha == item));
                    }

                    ViewBag.PPD = cantidad4.ToList();
                    ViewBag.PPD2 = pend5;
                    //FIN PENDIENTES POR FECHA

                    return View();
                }         
            }
            return View(reporteLlamadasViewModel);
        }

        public ActionResult RankingPendientes(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.Llamadas
                          where l.EstadoId == 2
                          && l.Activo == 0
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.NombreCliente } into g
                          select new LlamadaViewModel
                          {
                              NombreC = g.Key.NombreCliente,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }

        public ActionResult RankingPendientesPorUsuario(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.Llamadas
                          where l.EstadoId == 2
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.Usuario } into g
                          select new LlamadaViewModel
                          {
                              Usuario = g.Key.Usuario,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }
        
        public ActionResult RankingLlamadas(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.Llamadas
                          where l.EstadoId == 1
                          && l.Activo == 0
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.NombreCliente} into g
                          select new LlamadaViewModel
                          {
                              NombreC = g.Key.NombreCliente,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }
        
        public ActionResult RankingLlamadasPorUsuario(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.Llamadas
                          where l.EstadoId == 1
                          && l.Activo == 0
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.Usuario } into g
                          select new LlamadaViewModel
                          {
                              Usuario = g.Key.Usuario,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }

        public ActionResult RankingLlamadasPorCodigodeTarea(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.Llamadas 
                          join c in db.CodigosTareas on l.CodigoTareaId equals c.CodigoTareaId
                          join cl in db.CodigosEnLlamadas on l.LlamadaId equals cl.LlamadaId
                          where l.EstadoId == 1
                          && l.Activo == 0
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.CodigoTareaId , cl.CodigoTarea.Descripcion} into g
                          select new LlamadaViewModel
                          {
                              CodigoTareaId = g.Key.CodigoTareaId,
                              CodigoT = g.Key.Descripcion,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }

        public ActionResult RankingLlamadasSolicitadas(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.LlamadasSolicitadas
                          where l.Respuesta == true
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.Usuario } into g
                          select new LlamadaSolicitadaViewModel
                          {
                              Usuario = g.Key.Usuario,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }

        public ActionResult RankingLlamadasSolicitadasPorCliente(DateTime? desde, DateTime? hasta)
        {
            var result = (from l in db.LlamadasSolicitadas
                          where l.Respuesta == true
                          && l.Fecha >= desde && l.Fecha <= hasta
                          group l by new { l.NombreCliente } into g
                          select new LlamadaSolicitadaViewModel
                          {
                              NombreCliente = g.Key.NombreCliente,
                              Cantidad = g.Count()
                          }).Take(10);

            return PartialView(result.OrderByDescending(x => x.Cantidad));
        }


        [HttpPost]
        public ActionResult LlamadasSolicitadas(DateTime? desde, DateTime? hasta, ReporteLlamadasViewModel reporteLlamadasViewModel)
        {
            {
                if (ModelState.IsValid)
                {
                    //INICIO RESPUESTAS DE LLAMADAS SOLICITADAS
                    var list = db.LlamadasSolicitadas.Where(x => x.Respuesta == true & x.Fecha >= desde & x.Fecha <= hasta).ToList();

                    var list2 = list.Join(db.EstadosLlamadas, r => r.EstadoLlamadaId, p => p.EstadoLlamadaId, (r, p) => new { p.Descripcion });
                    var ord = list2.OrderBy(x => x.Descripcion);
                    List<int> cantidad = new List<int>();
                    var pend = ord.Select(x => x.Descripcion).Distinct();

                    foreach (var item in pend)
                    {
                        cantidad.Add(ord.Count(x => x.Descripcion == item));
                    }

                    var cant = cantidad;
                    ViewBag.RLS = cantidad.ToList();
                    ViewBag.forma1 = pend.ToList();
                    //FIN RESPUESTAS DE LLAMADAS SOLICITADAS

                    //INICIO LLAMADAS SOLICITADAS POR FECHA
                    var list1 = db.LlamadasSolicitadas.Where(x => x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var ord1 = list1.OrderBy(x => x.Fecha);
                    List<int> cantidad1 = new List<int>();
                    var pend1 = ord1.Select(x => x.Fecha).Distinct();
                    var pend2 = pend1.Select(x => x.ToShortDateString());

                    foreach (var item in pend1)
                    {
                        cantidad1.Add(ord1.Count(x => x.Fecha == item));
                    }

                    ViewBag.LLSPF = cantidad1.ToList();
                    ViewBag.LLSPF2 = pend2.ToList();
                    //FIN LLAMADAS SOLICITADAS POR FECHA


                    //INICIO LLAMADAS SOLICITADAS POR MES
                    var list4 = db.LlamadasSolicitadas.Where(x => x.Respuesta == true & x.Fecha >= desde & x.Fecha <= hasta).ToList();
                    var ord4 = list4.OrderBy(x => x.Fecha);
                    List<int> cantidad20 = new List<int>();
                    var pend4 = ord4.Select(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES"))).Distinct();

                    foreach (var item in pend4)
                    {
                        cantidad20.Add(ord1.Count(x => x.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es-ES")) == item));
                    }

                    ViewBag.LLSPM = cantidad20.ToList();
                    ViewBag.LLSPM2 = pend4;
                }

                return View();
            }
        }

    }
}