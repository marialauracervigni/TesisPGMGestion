namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoLlamada : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "EstadoLlamadaId_EstadoLlamadaId", "dbo.EstadoLlamadas");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "EstadoLlamadaId_EstadoLlamadaId" });
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EstadoLlamadaId_EstadoLlamadaId", newName: "EstadoLlamadaId");
            AlterColumn("dbo.LlamadaSolicitadas", "EstadoLlamadaId", c => c.Int(nullable: false));
            CreateIndex("dbo.LlamadaSolicitadas", "EstadoLlamadaId");
            AddForeignKey("dbo.LlamadaSolicitadas", "EstadoLlamadaId", "dbo.EstadoLlamadas", "EstadoLlamadaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LlamadaSolicitadas", "EstadoLlamadaId", "dbo.EstadoLlamadas");
            DropIndex("dbo.LlamadaSolicitadas", new[] { "EstadoLlamadaId" });
            AlterColumn("dbo.LlamadaSolicitadas", "EstadoLlamadaId", c => c.Int());
            RenameColumn(table: "dbo.LlamadaSolicitadas", name: "EstadoLlamadaId", newName: "EstadoLlamadaId_EstadoLlamadaId");
            CreateIndex("dbo.LlamadaSolicitadas", "EstadoLlamadaId_EstadoLlamadaId");
            AddForeignKey("dbo.LlamadaSolicitadas", "EstadoLlamadaId_EstadoLlamadaId", "dbo.EstadoLlamadas", "EstadoLlamadaId");
        }
    }
}
