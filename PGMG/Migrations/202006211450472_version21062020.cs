namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version21062020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Llamadas", "FormaDeComunicacionId", "dbo.FormaDeComunicacions");
            DropIndex("dbo.Llamadas", new[] { "FormaDeComunicacionId" });
            AddColumn("dbo.FormaDeComunicacions", "Seleccionado", c => c.Boolean(nullable: false));
            AddColumn("dbo.FormaDeComunicacions", "Llamada_LlamadaId", c => c.Int());
            CreateIndex("dbo.FormaDeComunicacions", "Llamada_LlamadaId");
            AddForeignKey("dbo.FormaDeComunicacions", "Llamada_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormaDeComunicacions", "Llamada_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.FormaDeComunicacions", new[] { "Llamada_LlamadaId" });
            DropColumn("dbo.FormaDeComunicacions", "Llamada_LlamadaId");
            DropColumn("dbo.FormaDeComunicacions", "Seleccionado");
            CreateIndex("dbo.Llamadas", "FormaDeComunicacionId");
            AddForeignKey("dbo.Llamadas", "FormaDeComunicacionId", "dbo.FormaDeComunicacions", "FormaDeComunicacionId", cascadeDelete: true);
        }
    }
}
