namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _241020201 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas");
            DropForeignKey("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.CodigoPorLlamadas", new[] { "CodigoTareaId_CodigoTareaId" });
            DropIndex("dbo.CodigoPorLlamadas", new[] { "LlamadaId_LlamadaId" });
            AddColumn("dbo.CodigoPorLlamadas", "LlamadaId", c => c.Int(nullable: false));
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId", c => c.Int(nullable: false));
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId");
            DropColumn("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId");
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
