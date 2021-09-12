namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _041020203 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LlamadasSolicitadasHists",
                c => new
                    {
                        LlamadasSolicitadasHistId = c.Int(nullable: false, identity: true),
                        LlamadaSolicitadaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        NombreCliente = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        NombreEmpleado = c.String(),
                        Usuario = c.String(),
                        EstadoLlamadaId = c.Int(nullable: false),
                        EstadoLlamada = c.String(),
                        Telefono = c.Int(),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.LlamadasSolicitadasHistId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoLlamadas", t => t.EstadoLlamadaId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.EstadoLlamadaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LlamadasSolicitadasHists", "EstadoLlamadaId", "dbo.EstadoLlamadas");
            DropForeignKey("dbo.LlamadasSolicitadasHists", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LlamadasSolicitadasHists", new[] { "EstadoLlamadaId" });
            DropIndex("dbo.LlamadasSolicitadasHists", new[] { "ClienteId" });
            DropTable("dbo.LlamadasSolicitadasHists");
        }
    }
}
