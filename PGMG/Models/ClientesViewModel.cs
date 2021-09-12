using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGMG.Models
{
    public class ClientesViewModel
    {
        private ApplicationDbContext contexto;

        public ClientesViewModel()
        {
            contexto = new ApplicationDbContext();
            Clientes = new List<ClientesBusqueda>();
            
        }

        public List<ClientesBusqueda> Clientes { get; set; }
        

        public List<Item> ClientesAutocompletar (string busqueda)
        {
            var consulta = from c in contexto.Clientes
                           where c.Nombre.Contains(busqueda)
                           select new Item
                           {
                               id = c.ClienteId.ToString(),
                               value = c.Nombre
                           };
            return consulta.ToList();
        }

        //public void BuscaPorNombre(string busqueda)
        //{
        //    var consulta = from c in contexto.Clientes
        //                   join p in contexto.Provincias on c.ProvinciaId equals p.ProvinciaId
        //                   where c.Nombre.Contains(busqueda)
        //                   select new
        //                   {
        //                       c.ClienteId,
        //                       c.Nombre,
        //                       c.Domicilio,
        //                       c.Localidad,
        //                       p.NombreP,
        //                       c.Telefono,
        //                       c.Correo,
        //                       c.FechaAlta,
        //                       c.FechaFundacion,
        //                   };
        //    Clientes.Clear();
        //    if (consulta != null)
        //    {
        //        var lcliente = consulta.ToList();
        //        foreach (var item in lcliente) 
        //        {
        //            Clientes.Add(new ClientesBusqueda
        //            {
        //                ClienteId = item.ClienteId,
        //                Nombre = item.Nombre,
        //                Domicilio = item.Domicilio,
        //                Localidad = item.Localidad,
        //                Provincia = item.NombreP,
        //                Telefono = item.Telefono,
        //                Correo = item.Correo,
        //                FechaAlta = item.FechaAlta,
        //                FechaFundacion = item.FechaFundacion
        //            });
        //        }
        //    }
        //}

        //public void BuscaPorEmpleado(string emple)
        //{

        //    var consulta = from cl in contexto.Clientes
        //                   join p in contexto.Provincias on cl.ProvinciaId equals p.ProvinciaId
        //                   where cl.ClienteId ==
        //                   (from e in cl.Empleados
        //                    where e.NombreCompleto.Contains(emple)
        //                    select cl.ClienteId).FirstOrDefault()
        //                   select new
        //                   {
        //                       cl.ClienteId,
        //                       cl.Nombre,
        //                       cl.Domicilio,
        //                       cl.Localidad,
        //                       p.NombreP,
        //                       cl.Telefono,
        //                       cl.Correo,
        //                       cl.FechaAlta,
        //                       cl.FechaFundacion
        //                   };
        //    Clientes.Clear();

        //    if (consulta != null)
        //    {
        //        var lclientes = consulta.ToList();
        //        foreach (var item in lclientes)
        //        {
        //            Clientes.Add(new ClientesBusqueda
        //            {
        //                ClienteId = item.ClienteId,
        //                Nombre = item.Nombre,
        //                Domicilio = item.Domicilio,
        //                Localidad = item.Localidad,
        //                Provincia = item.NombreP,
        //                Telefono = item.Telefono,
        //                Correo = item.Correo,
        //                FechaAlta = item.FechaAlta,
        //                FechaFundacion = item.FechaFundacion
        //            });
        //        }
        //    }

        //}

    }
    }