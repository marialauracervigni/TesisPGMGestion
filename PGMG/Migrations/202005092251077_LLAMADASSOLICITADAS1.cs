namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LLAMADASSOLICITADAS1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId_ClienteId", "dbo.Clientes");
            //DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId_ClienteId" });
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoId_EmpleadoId" });
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "ClienteId_ClienteId", newName: "ClienteId");
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EmpleadoId_EmpleadoId", newName: "EmpleadoId");
            AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int(nullable: false));
            //AlterColumn("dbo.LlamadaSolicitadas", "EmpleadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteId");
            //CreateIndex("dbo.LlamadaSolicitadas", "EmpleadoId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes", "ClienteId", cascadeDelete: true);
            //AddForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.LlamadaSolicitadas", "ClienteId", "dbo.Clientes");
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoId" });
            DropIndex("dbo.LlamadaSolicitadas", new[] { "ClienteId" });
           //AlterColumn("dbo.LlamadaSolicitadas", "EmpleadoId", c => c.Int());
            AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int());
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EmpleadoId", newName: "EmpleadoId_EmpleadoId");
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "ClienteId", newName: "ClienteId_ClienteId");
            //CreateIndex("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId");
            CreateIndex("dbo.LlamadaSolicitadas", "ClienteId_ClienteId");
            //AddForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
            AddForeignKey("dbo.LlamadaSolicitadas", "ClienteId_ClienteId", "dbo.Clientes", "ClienteId");
        }
    }
}
