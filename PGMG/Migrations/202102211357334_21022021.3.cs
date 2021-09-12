namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210220213 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodigoPorLlamada", "CodigoTareaId", "dbo.CodigoTareas");
            DropForeignKey("dbo.CodigoPorLlamada", "LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.CodigoPorLlamada", new[] { "LlamadaId" });
            DropIndex("dbo.CodigoPorLlamada", new[] { "CodigoTareaId" });
            DropTable("dbo.CodigoPorLlamada");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CodigoPorLlamadas",
                c => new
                    {
                        CodigoPorLlamadaId = c.Int(nullable: false, identity: true),
                        LlamadaId = c.Int(nullable: false),
                        CodigoTareaId = c.Int(nullable: false),
                        Seleccionado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoPorLlamadaId);
            
            CreateIndex("dbo.CodigoPorLlamadas", "CodigoTareaId");
            CreateIndex("dbo.CodigoPorLlamadas", "LlamadaId");
            AddForeignKey("dbo.CodigoPorLlamadas", "LlamadaId", "dbo.Llamadas", "LlamadaId", cascadeDelete: true);
            AddForeignKey("dbo.CodigoPorLlamadas", "CodigoTareaId", "dbo.CodigoTareas", "CodigoTareaId", cascadeDelete: true);
        }
    }
}
