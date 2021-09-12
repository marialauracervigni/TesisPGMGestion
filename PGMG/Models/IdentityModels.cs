using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGMG.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombre Completo")]
        public string NombreCompleto { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            userIdentity.AddClaim(new Claim("NombreCompleto", this.NombreCompleto));
            return userIdentity;
        }
        public virtual ICollection<Llamada> Llamadas { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public System.Data.Entity.DbSet<PGMG.Models.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.CodigoTarea> CodigosTareas { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Estado> Estados { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.EstadoLlamada> EstadosLlamadas { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Etiqueta> Etiquetas { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.FormaDeComunicacion> FormasDeComunicacion { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Llamada> Llamadas { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.LlamadaHist> LlamadasHist { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.LlamadaSolicitada> LlamadasSolicitadas { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Provincia> Provincias { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.LlamadasSolicitadasHist> LlamadasSolicitadasHists { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Viajes> Viajes { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.Events> Events { get; set; }
        public System.Data.Entity.DbSet<PGMG.Models.CodigosEnLlamada> CodigosEnLlamadas { get; set; }

    }
}