namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25102020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas");
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            DropIndex("dbo.Llamadas", new[] { "EtiquetaId" });
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int());
            AlterColumn("dbo.Llamadas", "EtiquetaId", c => c.Int());
            CreateIndex("dbo.Llamadas", "EstadoId");
            CreateIndex("dbo.Llamadas", "EtiquetaId");
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas");
            DropForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes");
            DropIndex("dbo.Llamadas", new[] { "EtiquetaId" });
            DropIndex("dbo.Llamadas", new[] { "EstadoId" });
            AlterColumn("dbo.Llamadas", "EtiquetaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Llamadas", "EstadoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Llamadas", "EtiquetaId");
            CreateIndex("dbo.Llamadas", "EstadoId");
            AddForeignKey("dbo.Llamadas", "EtiquetaId", "dbo.Etiquetas", "EtiquetaId", cascadeDelete: true);
            AddForeignKey("dbo.Llamadas", "EstadoId", "dbo.Estadoes", "EstadoId", cascadeDelete: true);
        }
    }
}
