namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09122020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viajes",
                c => new
                    {
                        ViajesId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        NombreCliente = c.String(),
                        FechaDesde = c.DateTime(nullable: false),
                        FechaHasta = c.DateTime(nullable: false),
                        Usuario = c.String(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.ViajesId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viajes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Viajes", new[] { "ClienteId" });
            DropTable("dbo.Viajes");
        }
    }
}
