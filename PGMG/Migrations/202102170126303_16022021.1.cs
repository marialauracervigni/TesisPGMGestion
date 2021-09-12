namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _160220211 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LlamadasSolicitadasHists", "UsuarioTelef", c => c.String());
            AddColumn("dbo.LlamadasSolicitadasHists", "Respuesta", c => c.Boolean(nullable: false));
            AddColumn("dbo.LlamadasSolicitadasHists", "LlamadaId", c => c.Int());
            AddColumn("dbo.LlamadasSolicitadasHists", "Activo", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LlamadasSolicitadasHists", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LlamadasSolicitadasHists", "Telefono", c => c.Int());
            DropColumn("dbo.LlamadasSolicitadasHists", "Activo");
            DropColumn("dbo.LlamadasSolicitadasHists", "LlamadaId");
            DropColumn("dbo.LlamadasSolicitadasHists", "Respuesta");
            DropColumn("dbo.LlamadasSolicitadasHists", "UsuarioTelef");
        }
    }
}
