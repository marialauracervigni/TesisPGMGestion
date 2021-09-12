namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _04102020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaHists", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.LlamadaHists", "EstadoId_EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.LlamadaHists", "EtiquetaId_EtiquetaId", "dbo.Etiquetas");
            DropIndex("dbo.LlamadaHists", new[] { "EstadoId_EstadoId" });
            DropIndex("dbo.LlamadaHists", new[] { "EtiquetaId_EtiquetaId" });
            DropIndex("dbo.LlamadaHists", new[] { "LlamadaId_LlamadaId" });
            RenameColumn(table: "dbo.LlamadaHists", name: "EstadoId_EstadoId", newName: "EstadoId");
            RenameColumn(table: "dbo.LlamadaHists", name: "EtiquetaId_EtiquetaId", newName: "EtiquetaId");
            AddColumn("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId", c => c.Int());
            AddColumn("dbo.LlamadaHists", "ClienteId", c => c.Int(nullable: false));
            AddColumn("dbo.LlamadaHists", "NombreCliente", c => c.String());
            AddColumn("dbo.LlamadaHists", "Hora", c => c.DateTime(nullable: false));
            AddColumn("dbo.LlamadaHists", "NombreEmpleado", c => c.String());
            AddColumn("dbo.LlamadaHists", "FormaDeComunicacionId", c => c.Int(nullable: false));
            AddColumn("dbo.LlamadaHists", "Tema", c => c.String());
            AddColumn("dbo.LlamadaHists", "CodigoTareaId", c => c.Int(nullable: false));
            AddColumn("dbo.LlamadaHists", "seleccionado", c => c.Boolean(nullable: false));
            AddColumn("dbo.LlamadaHists", "TiempoEnLlamado", c => c.Int(nullable: false));
            AddColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.Int(nullable: false));
            AddColumn("dbo.LlamadaHists", "Empleado_EmpleadoId", c => c.Int());
            AlterColumn("dbo.LlamadaHists", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "EtiquetaId", c => c.Int(nullable: false));
            CreateIndex("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId");
            CreateIndex("dbo.LlamadaHists", "ClienteId");
            CreateIndex("dbo.LlamadaHists", "EstadoId");
            CreateIndex("dbo.LlamadaHists", "EtiquetaId");
            CreateIndex("dbo.LlamadaHists", "Empleado_EmpleadoId");
            AddForeignKey("dbo.LlamadaHists", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId", "dbo.LlamadaHists", "LLamadaHistId");
            AddForeignKey("dbo.LlamadaHists", "Empleado_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
            AddForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
            AddForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId", cascadeDelete: true);
            DropColumn("dbo.LlamadaHists", "DuracionTarea");
            DropColumn("dbo.LlamadaHists", "LlamadaId_LlamadaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaHists", "LlamadaId_LlamadaId", c => c.Int());
            AddColumn("dbo.LlamadaHists", "DuracionTarea", c => c.Int(nullable: false));
            DropForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.LlamadaHists", "Empleado_EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId", "dbo.LlamadaHists");
            DropForeignKey("dbo.LlamadaHists", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadaHists", new[] { "Empleado_EmpleadoId" });
            DropIndex("dbo.LlamadaHists", new[] { "EtiquetaId" });
            DropIndex("dbo.LlamadaHists", new[] { "EstadoId" });
            DropIndex("dbo.LlamadaHists", new[] { "ClienteId" });
            DropIndex("dbo.CodigoTareas", new[] { "LlamadaHist_LLamadaHistId" });
            AlterColumn("dbo.LlamadaHists", "EtiquetaId", c => c.Int());
            AlterColumn("dbo.LlamadaHists", "EstadoId", c => c.Int());
            DropColumn("dbo.LlamadaHists", "Empleado_EmpleadoId");
            DropColumn("dbo.LlamadaHists", "TiempoPostLlamado");
            DropColumn("dbo.LlamadaHists", "TiempoEnLlamado");
            DropColumn("dbo.LlamadaHists", "seleccionado");
            DropColumn("dbo.LlamadaHists", "CodigoTareaId");
            DropColumn("dbo.LlamadaHists", "Tema");
            DropColumn("dbo.LlamadaHists", "FormaDeComunicacionId");
            DropColumn("dbo.LlamadaHists", "NombreEmpleado");
            DropColumn("dbo.LlamadaHists", "Hora");
            DropColumn("dbo.LlamadaHists", "NombreCliente");
            DropColumn("dbo.LlamadaHists", "ClienteId");
            DropColumn("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId");
            RenameColumn(table: "dbo.LlamadaHists", name: "EtiquetaId", newName: "EtiquetaId_EtiquetaId");
            RenameColumn(table: "dbo.LlamadaHists", name: "EstadoId", newName: "EstadoId_EstadoId");
            CreateIndex("dbo.LlamadaHists", "LlamadaId_LlamadaId");
            CreateIndex("dbo.LlamadaHists", "EtiquetaId_EtiquetaId");
            CreateIndex("dbo.LlamadaHists", "EstadoId_EstadoId");
            AddForeignKey("dbo.LlamadaHists", "EtiquetaId_EtiquetaId", "dbo.Etiquetas", "EtiquetaId");
            AddForeignKey("dbo.LlamadaHists", "EstadoId_EstadoId", "dbo.Estadoes", "EstadoId");
            AddForeignKey("dbo.LlamadaHists", "LlamadaId_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
    }
}
