namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version131 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "EmpleadoId_EmpleadoId" });
            DropColumn("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", c => c.Int());
            CreateIndex("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId");
            AddForeignKey("dbo.LlamadaSolicitadas", "EmpleadoId_EmpleadoId", "dbo.Empleadoes", "EmpleadoId");
        }
    }
}
