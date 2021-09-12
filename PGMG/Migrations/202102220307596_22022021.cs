namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22022021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormaDeComunicacions", "LlamadaSolicitada_LlamadaSolicitadaId", c => c.Int());
            AddColumn("dbo.LlamadaSolicitadas", "FormaDeComunicacionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "Tema", c => c.String());
            AlterColumn("dbo.Llamadas", "Descripcion", c => c.String());
            CreateIndex("dbo.FormaDeComunicacions", "LlamadaSolicitada_LlamadaSolicitadaId");
            AddForeignKey("dbo.FormaDeComunicacions", "LlamadaSolicitada_LlamadaSolicitadaId", "dbo.LlamadaSolicitadas", "LlamadaSolicitadaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormaDeComunicacions", "LlamadaSolicitada_LlamadaSolicitadaId", "dbo.LlamadaSolicitadas");
            DropIndex("dbo.FormaDeComunicacions", new[] { "LlamadaSolicitada_LlamadaSolicitadaId" });
            AlterColumn("dbo.Llamadas", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Llamadas", "Tema", c => c.String(nullable: false));
            DropColumn("dbo.LlamadaSolicitadas", "FormaDeComunicacionId");
            DropColumn("dbo.FormaDeComunicacions", "LlamadaSolicitada_LlamadaSolicitadaId");
        }
    }
}
