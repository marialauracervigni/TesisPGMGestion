namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15112020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas");
            DropIndex("dbo.CodigoTareas", new[] { "LlamadaHist_LLamadaHistId" });
            DropIndex("dbo.LlamadaHists", new[] { "EstadoId" });
            DropIndex("dbo.LlamadaHists", new[] { "EtiquetaId" });
            AddColumn("dbo.FormaDeComunicacions", "LlamadaHist_LlamadaHistId", c => c.Int());
            AddColumn("dbo.LlamadaHists", "Activo", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "CodigoTareaId", c => c.Int());
            AlterColumn("dbo.LlamadaHists", "TiempoEnLlamado", c => c.String());
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.Int());
            AlterColumn("dbo.LlamadaHists", "EstadoId", c => c.Int());
            AlterColumn("dbo.LlamadaHists", "EtiquetaId", c => c.Int());
            CreateIndex("dbo.CodigoTareas", "LlamadaHist_LlamadaHistId");
            CreateIndex("dbo.FormaDeComunicacions", "LlamadaHist_LlamadaHistId");
            CreateIndex("dbo.LlamadaHists", "EstadoId");
            CreateIndex("dbo.LlamadaHists", "EtiquetaId");
            AddForeignKey("dbo.FormaDeComunicacions", "LlamadaHist_LlamadaHistId", "dbo.LlamadaHists", "LlamadaHistId");
            AddForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes", "EstadoId");
            AddForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId");
            DropColumn("dbo.LlamadaHists", "seleccionado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LlamadaHists", "seleccionado", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.FormaDeComunicacions", "LlamadaHist_LlamadaHistId", "dbo.LlamadaHists");
            DropIndex("dbo.LlamadaHists", new[] { "EtiquetaId" });
            DropIndex("dbo.LlamadaHists", new[] { "EstadoId" });
            DropIndex("dbo.FormaDeComunicacions", new[] { "LlamadaHist_LlamadaHistId" });
            DropIndex("dbo.CodigoTareas", new[] { "LlamadaHist_LlamadaHistId" });
            AlterColumn("dbo.LlamadaHists", "EtiquetaId", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "EstadoId", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "TiempoPostLlamado", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "TiempoEnLlamado", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaHists", "CodigoTareaId", c => c.Int(nullable: false));
            DropColumn("dbo.LlamadaHists", "Activo");
            DropColumn("dbo.FormaDeComunicacions", "LlamadaHist_LlamadaHistId");
            CreateIndex("dbo.LlamadaHists", "EtiquetaId");
            CreateIndex("dbo.LlamadaHists", "EstadoId");
            CreateIndex("dbo.CodigoTareas", "LlamadaHist_LLamadaHistId");
            AddForeignKey("dbo.LlamadaHists", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId", cascadeDelete: true);
            AddForeignKey("dbo.LlamadaHists", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
        }
    }
}
