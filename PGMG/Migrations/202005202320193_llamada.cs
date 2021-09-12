namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class llamada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Llamadas", "ClienteId_ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Llamadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Llamadas", "EstadoId_EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Llamadas", "EtiquetaId_EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.Llamadas", "FormaDeComunicacionId_FormaDeComunicacionId", "dbo.FormaDeComunicacions");
            DropIndex("dbo.Llamadas", new[] { "ClienteId_ClienteId" });
            DropIndex("dbo.Llamadas", new[] { "EmpleadoId_EmpleadoId" });
            DropIndex("dbo.Llamadas", new[] { "EstadoId_EstadoId" });
            DropIndex("dbo.Llamadas", new[] { "EtiquetaId_EtiquetaId" });
            DropIndex("dbo.Llamadas", new[] { "FormaDeComunicacionId_FormaDeComunicacionId" });
            RenameColumn(table: "dbo.Llamadas", name: "ClienteId_ClienteId", newName: "ClienteId");
            RenameColumn(table: "dbo.Llamadas", name: "EmpleadoId_EmpleadoId", newName: "EmpleadoId");
            RenameColumn(table: "dbo.Llamadas", name: "EstadoId_EstadoId", newName: "EstadoId");
            RenameColumn(table: "dbo.Llamadas", name: "EtiquetaId_EtiquetaId", newName: "EtiquetaId");
            RenameColumn(table: "dbo.Llamadas", name: "FormaDeComunicacionId_FormaDeComunicacionId", newName: "FormaDeComunicacionId");
            AddColumn("dbo.Llamadas", "CodigoTareaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "EmpleadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "EtiquetaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "FormaDeComunicacionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Llamadas", "ClienteId");
            CreateIndex("dbo.Llamadas", "EmpleadoId");
            CreateIndex("dbo.Llamadas", "FormaDeComunicacionId");
            CreateIndex("dbo.Llamadas", "EstadoId");
            CreateIndex("dbo.Llamadas", "EtiquetaId");
            AddForeignKey("dbo.Llamadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            //AddForeignKey("dbo.Llamadas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
            AddForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId", cascadeDelete: true);
            AddForeignKey("dbo.Llamadas", "FormaDeComunicacionId", "dbo.FormaDeComunicacions", "FormaDeComunicacionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Llamadas", "FormaDeComunicacionId", "dbo.FormaDeComunicacions");
            DropForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Llamadas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Llamadas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Llamadas", new[] { "EtiquetaId" });
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            DropIndex("dbo.Llamadas", new[] { "FormaDeComunicacionId" });
            DropIndex("dbo.Llamadas", new[] { "EmpleadoId" });
            DropIndex("dbo.Llamadas", new[] { "ClienteId" });
            AlterColumn("dbo.Llamadas", "FormaDeComunicacionId", c => c.Int());
            AlterColumn("dbo.Llamadas", "EtiquetaId", c => c.Int());
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int());
            AlterColumn("dbo.Llamadas", "EmpleadoId", c => c.Int());
            AlterColumn("dbo.Llamadas", "ClienteId", c => c.Int());
            DropColumn("dbo.Llamadas", "CodigoTareaId");
            RenameColumn(table: "dbo.Llamadas", name: "FormaDeComunicacionId", newName: "FormaDeComunicacionId_FormaDeComunicacionId");
            RenameColumn(table: "dbo.Llamadas", name: "EtiquetaId", newName: "EtiquetaId_EtiquetaId");
            RenameColumn(table: "dbo.Llamadas", name: "EstadoId", newName: "EstadoId_EstadoId");
            RenameColumn(table: "dbo.Llamadas", name: "EmpleadoId", newName: "EmpleadoId_EmpleadoId");
            RenameColumn(table: "dbo.Llamadas", name: "ClienteId", newName: "ClienteId_ClienteId");
            CreateIndex("dbo.Llamadas", "FormaDeComunicacionId_FormaDeComunicacionId");
            CreateIndex("dbo.Llamadas", "EtiquetaId_EtiquetaId");
            CreateIndex("dbo.Llamadas", "EstadoId_EstadoId");
            CreateIndex("dbo.Llamadas", "EmpleadoId_EmpleadoId");
            CreateIndex("dbo.Llamadas", "ClienteId_ClienteId");
            AddForeignKey("dbo.Llamadas", "FormaDeComunicacionId_FormaDeComunicacionId", "dbo.FormaDeComunicacions", "FormaDeComunicacionId");
            AddForeignKey("dbo.Llamadas", "EtiquetaId_EtiquetaId", "dbo.Etiquetas", "EtiquetaId");
            AddForeignKey("dbo.Llamadas", "EstadoId_EstadoId", "dbo.Estadoes", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
            AddForeignKey("dbo.Llamadas", "ClienteId_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
