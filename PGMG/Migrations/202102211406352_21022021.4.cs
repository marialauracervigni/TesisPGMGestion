namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _210220214 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodigosEnLlamadas",
                c => new
                    {
                        CodigosEnLlamadaId = c.Int(nullable: false, identity: true),
                        LlamadaId = c.Int(nullable: false),
                        CodigoTareaId = c.Int(nullable: false),
                        Seleccionado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CodigosEnLlamadaId)
                .ForeignKey("dbo.CodigoTareas", t => t.CodigoTareaId, cascadeDelete: true)
                .ForeignKey("dbo.Llamadas", t => t.LlamadaId, cascadeDelete: true)
                .Index(t => t.LlamadaId)
                .Index(t => t.CodigoTareaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodigosEnLlamadas", "LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.CodigosEnLlamadas", "CodigoTareaId", "dbo.CodigoTareas");
            DropIndex("dbo.CodigosEnLlamadas", new[] { "CodigoTareaId" });
            DropIndex("dbo.CodigosEnLlamadas", new[] { "LlamadaId" });
            DropTable("dbo.CodigosEnLlamadas");
        }
    }
}
