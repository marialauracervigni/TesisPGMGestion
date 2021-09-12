namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClasesSistema : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.Llamadas", "EstadoDelTicket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Llamadas", "TicketId_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Llamadas", "TipoDeTicket_TicketId", "dbo.Tickets");
            DropIndex("dbo.Llamadas", new[] { "EstadoDelTicket_TicketId" });
            DropIndex("dbo.Llamadas", new[] { "TicketId_TicketId" });
            DropIndex("dbo.Llamadas", new[] { "TipoDeTicket_TicketId" });
            DropIndex("dbo.Tickets", new[] { "LlamadaId_LlamadaId" });
            CreateTable(
                "dbo.Moduloes",
                c => new
                    {
                        ModuloId = c.Int(nullable: false, identity: true),
                        CodigoModulo = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ModuloId);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.EstadoLlamadas",
                c => new
                    {
                        EstadoLlamadaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoLlamadaId);
            
            CreateTable(
                "dbo.Etiquetas",
                c => new
                    {
                        EtiquetaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EtiquetaId);
            
            CreateTable(
                "dbo.LlamadaHists",
                c => new
                    {
                        LLamadaHistId = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        DuracionTarea = c.Int(nullable: false),
                        EstadoId_EstadoId = c.Int(),
                        EtiquetaId_EtiquetaId = c.Int(),
                        LlamadaId_LlamadaId = c.Int(),
                    })
                .PrimaryKey(t => t.LLamadaHistId)
                .ForeignKey("dbo.Estadoes", t => t.EstadoId_EstadoId)
                .ForeignKey("dbo.Etiquetas", t => t.EtiquetaId_EtiquetaId)
                .ForeignKey("dbo.Llamadas", t => t.LlamadaId_LlamadaId)
                .Index(t => t.EstadoId_EstadoId)
                .Index(t => t.EtiquetaId_EtiquetaId)
                .Index(t => t.LlamadaId_LlamadaId);
            
            CreateTable(
                "dbo.LlamadaSolicitadas",
                c => new
                    {
                        LlamadaSolicitadaId = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        ClienteId_ClienteId = c.Int(),
                        EmpleadoId_EmpleadoId = c.Int(),
                        EstadoLlamadaId_EstadoLlamadaId = c.Int(),
                    })
                .PrimaryKey(t => t.LlamadaSolicitadaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId_ClienteId)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId_EmpleadoId)
                .ForeignKey("dbo.EstadoLlamadas", t => t.EstadoLlamadaId_EstadoLlamadaId)
                .Index(t => t.ClienteId_ClienteId)
                .Index(t => t.EmpleadoId_EmpleadoId)
                .Index(t => t.EstadoLlamadaId_EstadoLlamadaId);
            
            AddColumn("dbo.Clientes", "CodigosModulos_ModuloId", c => c.Int());
            AddColumn("dbo.Llamadas", "Usuario", c => c.String());
            AddColumn("dbo.Llamadas", "EstadoId_EstadoId", c => c.Int());
            AddColumn("dbo.Llamadas", "EtiquetaId_EtiquetaId", c => c.Int());
            CreateIndex("dbo.Clientes", "CodigosModulos_ModuloId");
            CreateIndex("dbo.Llamadas", "EstadoId_EstadoId");
            CreateIndex("dbo.Llamadas", "EtiquetaId_EtiquetaId");
            AddForeignKey("dbo.Clientes", "CodigosModulos_ModuloId", "dbo.Moduloes", "ModuloId");
            AddForeignKey("dbo.Llamadas", "EstadoId_EstadoId", "dbo.Estadoes", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EtiquetaId_EtiquetaId", "dbo.Etiquetas", "EtiquetaId");
            DropColumn("dbo.Llamadas", "EstadoDelTicket_TicketId");
            DropColumn("dbo.Llamadas", "TicketId_TicketId");
            DropColumn("dbo.Llamadas", "TipoDeTicket_TicketId");
            //DropTable("dbo.Tickets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        NumeroDeTicket = c.Int(nullable: false),
                        TipoDeTicket = c.Int(nullable: false),
                        DescTipoT = c.String(),
                        EstadoDelTicket = c.Int(nullable: false),
                        DescEstadoDelT = c.String(),
                        Responsable = c.String(),
                        LlamadaId_LlamadaId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId);
            
            AddColumn("dbo.Llamadas", "TipoDeTicket_TicketId", c => c.Int());
            AddColumn("dbo.Llamadas", "TicketId_TicketId", c => c.Int());
            AddColumn("dbo.Llamadas", "EstadoDelTicket_TicketId", c => c.Int());
            DropForeignKey("dbo.LlamadaSolicitadas", "EstadoLlamadaId_EstadoLlamadaId", "dbo.EstadoLlamadas");
            DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LlamadaHists", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.LlamadaHists", "EtiquetaId_EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.LlamadaHists", "EstadoId_EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Llamadas", "EtiquetaId_EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.Llamadas", "EstadoId_EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Clientes", "CodigosModulos_ModuloId", "dbo.Moduloes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "EstadoLlamadaId_EstadoLlamadaId" });
            DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoId_EmpleadoId" });
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId_ClienteId" });
            DropIndex("dbo.LlamadaHists", new[] { "LlamadaId_LlamadaId" });
            DropIndex("dbo.LlamadaHists", new[] { "EtiquetaId_EtiquetaId" });
            DropIndex("dbo.LlamadaHists", new[] { "EstadoId_EstadoId" });
            DropIndex("dbo.Llamadas", new[] { "EtiquetaId_EtiquetaId" });
            DropIndex("dbo.Llamadas", new[] { "EstadoId_EstadoId" });
            DropIndex("dbo.Clientes", new[] { "CodigosModulos_ModuloId" });
            DropColumn("dbo.Llamadas", "EtiquetaId_EtiquetaId");
            DropColumn("dbo.Llamadas", "EstadoId_EstadoId");
            DropColumn("dbo.Llamadas", "Usuario");
            DropColumn("dbo.Clientes", "CodigosModulos_ModuloId");
            DropTable("dbo.LlamadaSolicitadas");
            DropTable("dbo.LlamadaHists");
            DropTable("dbo.Etiquetas");
            DropTable("dbo.EstadoLlamadas");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Moduloes");
            CreateIndex("dbo.Tickets", "LlamadaId_LlamadaId");
            CreateIndex("dbo.Llamadas", "TipoDeTicket_TicketId");
            CreateIndex("dbo.Llamadas", "TicketId_TicketId");
            CreateIndex("dbo.Llamadas", "EstadoDelTicket_TicketId");
            AddForeignKey("dbo.Llamadas", "TipoDeTicket_TicketId", "dbo.Tickets", "TicketId");
            AddForeignKey("dbo.Llamadas", "TicketId_TicketId", "dbo.Tickets", "TicketId");
            AddForeignKey("dbo.Llamadas", "EstadoDelTicket_TicketId", "dbo.Tickets", "TicketId");
            AddForeignKey("dbo.Tickets", "LlamadaId_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
    }
}
