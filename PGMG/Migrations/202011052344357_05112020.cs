namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05112020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigoTareas", "Llamada_LlamadaId", c => c.Int());
            CreateIndex("dbo.CodigoTareas", "Llamada_LlamadaId");
            AddForeignKey("dbo.CodigoTareas", "Llamada_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodigoTareas", "Llamada_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.CodigoTareas", new[] { "Llamada_LlamadaId" });
            DropColumn("dbo.CodigoTareas", "Llamada_LlamadaId");
        }
    }
}
