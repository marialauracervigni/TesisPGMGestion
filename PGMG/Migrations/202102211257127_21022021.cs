namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21022021 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas");
            DropForeignKey("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.CodigoPorLlamada", new[] { "CodigoTareaId_CodigoTareaId" });
            DropIndex("dbo.CodigoPorLlamada", new[] { "LlamadaId_LlamadaId" });
            AddColumn("dbo.CodigoPorLlamada", "LlamadaId", c => c.Int(nullable: false));
            AddColumn("dbo.CodigoPorLlamada", "CodigoTareaId", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId");
            DropColumn("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", c => c.Int());
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", c => c.Int());
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId");
            DropColumn("dbo.CodigoPorLlamadas", "LlamadaId");
            CreateIndex("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId");
            CreateIndex("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId");
            AddForeignKey("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", "dbo.Llamadas", "LlamadaId");
            AddForeignKey("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas", "CodigoTareaId");
        }
    }
}
