namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03032021 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moduloes", "Cliente_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.EmpleadosClientes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.LlamadasEnCursoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", "dbo.LlamadasEnCursoes");
            DropIndex("dbo.Moduloes", new[] { "Cliente_ClienteId" });
            DropIndex("dbo.FormaDeComunicacions", new[] { "LlamadasEnCurso_LlamadasEnCursoId" });
            DropIndex("dbo.EmpleadosClientes", new[] { "ClienteId" });
            DropIndex("dbo.LlamadasEnCursoes", new[] { "ClienteId" });
            DropColumn("dbo.CodigosEnLlamadas", "Seleccionado");
            DropColumn("dbo.Llamadas", "EmpleadoId");
            DropColumn("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId");
            DropTable("dbo.Moduloes");
            DropTable("dbo.EmpleadosClientes");
            DropTable("dbo.LlamadasEnCursoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LlamadasEnCursoes",
                c => new
                    {
                        LlamadasEnCursoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        NombreCliente = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        NombreEmpleado = c.String(nullable: false),
                        FormaDeComunicacionId = c.Int(nullable: false),
                        Usuario = c.String(nullable: false),
                        Activo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LlamadasEnCursoId);
            
            CreateTable(
                "dbo.EmpleadosClientes",
                c => new
                    {
                        EmpleadosClientesId = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false),
                        Puesto = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Correo = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadosClientesId);
            
            CreateTable(
                "dbo.Moduloes",
                c => new
                    {
                        ModuloId = c.Int(nullable: false, identity: true),
                        CodigoModulo = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Cliente_ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ModuloId);
            
            AddColumn("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", c => c.Int());
            AddColumn("dbo.Llamadas", "EmpleadoId", c => c.Int(nullable: false));
            AddColumn("dbo.CodigosEnLlamadas", "Seleccionado", c => c.Boolean(nullable: false));
            CreateIndex("dbo.LlamadasEnCursoes", "ClienteId");
            CreateIndex("dbo.EmpleadosClientes", "ClienteId");
            CreateIndex("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId");
            CreateIndex("dbo.Moduloes", "Cliente_ClienteId");
            AddForeignKey("dbo.FormaDeComunicacions", "LlamadasEnCurso_LlamadasEnCursoId", "dbo.LlamadasEnCursoes", "LlamadasEnCursoId");
            AddForeignKey("dbo.LlamadasEnCursoes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.EmpleadosClientes", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Moduloes", "Cliente_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
