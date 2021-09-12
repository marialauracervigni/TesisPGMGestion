namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20102020 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LlamadaEncabezadoes", "Llamada_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.LlamadaEncabezadoes", new[] { "Llamada_LlamadaId" });
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", c => c.Int());
            AddColumn("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", c => c.Int());
            CreateIndex("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId");
            CreateIndex("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId");
            AddForeignKey("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas", "CodigoTareaId");
            AddForeignKey("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", "dbo.Llamadas", "LlamadaId");
            DropColumn("dbo.CodigoPorLlamadas", "LlamadaId");
           
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId");
            DropTable("dbo.LlamadaEncabezadoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LlamadaEncabezadoes",
                c => new
                    {
                        LlamadaEncabezadoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        Llamada_LlamadaId = c.Int(),
                    })
                .PrimaryKey(t => t.LlamadaEncabezadoId);
            
            AddColumn("dbo.CodigoPorLlamadas", "CodigoTareaId", c => c.Int(nullable: false));
            AddColumn("dbo.CodigoPorLlamadas", "LlamadaId", c => c.Int(nullable: false));
            
            DropForeignKey("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId", "dbo.Llamadas");
            DropForeignKey("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId", "dbo.CodigoTareas");
            DropIndex("dbo.CodigoPorLlamadas", new[] { "LlamadaId_LlamadaId" });
            DropIndex("dbo.CodigoPorLlamadas", new[] { "CodigoTareaId_CodigoTareaId" });
            DropColumn("dbo.CodigoPorLlamadas", "LlamadaId_LlamadaId");
            DropColumn("dbo.CodigoPorLlamadas", "CodigoTareaId_CodigoTareaId");
            CreateIndex("dbo.LlamadaEncabezadoes", "Llamada_LlamadaId");
            AddForeignKey("dbo.LlamadaEncabezadoes", "Llamada_LlamadaId", "dbo.Llamadas", "LlamadaId");
        }
    }
}
