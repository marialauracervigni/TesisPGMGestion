namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _241020202 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodigoTareas", "Llamada_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.CodigoTareas", new[] { "Llamada_LlamadaId" });
            AddColumn("dbo.CodigoPorLlamadas", "Codigo", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId");
            DropColumn("dbo.CodigoTareas", "Llamada_LlamadaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodigoTareas", "Llamada_LlamadaId", c => c.Int());
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamadas", "Codigo");
            CreateIndex("dbo.CodigoTareas", "Llamada_LlamadaId");
            AddForeignKey("dbo.CodigoTareas", "Llamada_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
    }
}
