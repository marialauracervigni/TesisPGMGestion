namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version13 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId", "dbo.Empleadoes");
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoId" });
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EmpleadoId", newName: "EmpleadoLlamadaSolic_EmpleadoId");
            //AlterColumn("dbo.LlamadaSolicitadas", "EmpleadoLlamadaSolic_EmpleadoId", c => c.Int());
            //CreateIndex("dbo.LlamadaSolicitadas", "EmpleadoLlamadaSolic_EmpleadoId");
            //AddForeignKey("dbo.LlamadaSolicitadas", "EmpleadoLlamadaSolic_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoLlamadaSolic_EmpleadoId", "dbo.Empleadoes");
            //DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoLlamadaSolic_EmpleadoId" });
            //AlterColumn("dbo.LlamadaSolicitadas", "EmpleadoLlamadaSolic_EmpleadoId", c => c.Int(nullable: false));
            //RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EmpleadoLlamadaSolic_EmpleadoId", newName: "EmpleadoId");
            //CreateIndex("dbo.LlamadaSolicitadas", "EmpleadoId");
            //AddForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId", "dbo.Empleadoes", "EmpleadoId", cascadeDelete: true);
        }
    }
}
