namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03122020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId", c => c.Int());
            AddColumn("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId", c => c.Int());
            CreateIndex("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId");
            CreateIndex("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId");
            AddForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas", "CodigoTareaId");
            AddForeignKey("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId", "dbo.Llamadas", "LlamadaId");
            DropColumn("dbo.CodigoPorLlamada", "LlamadaId");
            DropColumn("dbo.CodigoPorLlamada", "CodigoTareaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodigoPorLlamada", "CodigoTareaId", c => c.Int(nullable: false));
            AddColumn("dbo.CodigoPorLlamada", "LlamadaId", c => c.Int(nullable: false));
            DropForeignKey("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas");
            DropIndex("dbo.CodigoPorLlamada", new[] { "LlamadaId_LlamadaId" });
            DropIndex("dbo.CodigoPorLlamada", new[] { "CodigoTareaId_CodigoTareaId" });
            DropColumn("dbo.CodigoPorLlamada", "LlamadaId_LlamadaId");
            DropColumn("dbo.CodigoPorLlamada", "CodigoTareaId_CodigoTareaId");
        }
    }
}
