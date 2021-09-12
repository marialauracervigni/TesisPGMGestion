namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210220211 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CodigoPorLlamada", "LlamadaId");
            CreateIndex("dbo.CodigoPorLlamada", "CodigoTareaId");
            AddForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId", "dbo.CodigoTareas", "CodigoTareaId", cascadeDelete: true);
            AddForeignKey("dbo.CodigoPorLlamada", "LlamadaId", "dbo.Llamadas", "LlamadaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodigoPorLlamada", "LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId", "dbo.CodigoTareas");
            DropIndex("dbo.CodigoPorLlamada", new[] { "CodigoTareaId" });
            DropIndex("dbo.CodigoPorLlamada", new[] { "LlamadaId" });
        }
    }
}
