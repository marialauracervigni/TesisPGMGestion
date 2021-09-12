namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10102020 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.LlamadaEncabezadoId)
                .ForeignKey("dbo.Llamadas", t => t.Llamada_LlamadaId)
                .Index(t => t.Llamada_LlamadaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LlamadaEncabezadoes", "Llamada_LlamadaId", "dbo.Llamadas");
            DropIndex("dbo.LlamadaEncabezadoes", new[] { "Llamada_LlamadaId" });
            DropTable("dbo.LlamadaEncabezadoes");
        }
    }
}
