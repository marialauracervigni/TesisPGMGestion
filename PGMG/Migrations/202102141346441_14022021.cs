namespace PGMG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14022021 : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int(nullable: false));
            AlterColumn("dbo.LlamadaSolicitadas", "NombreCliente", c => c.String(nullable: false));
            AlterColumn("dbo.LlamadaSolicitadas", "NombreEmpleado", c => c.String(nullable: false));
            AlterColumn("dbo.LlamadaSolicitadas", "UsuarioTelef", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.LlamadaSolicitadas", "ClienteId", c => c.Int(nullable: true));
            AlterColumn("dbo.LlamadaSolicitadas", "NombreCliente", c => c.String(nullable: true));
            AlterColumn("dbo.LlamadaSolicitadas", "NombreEmpleado", c => c.String(nullable: true));
            AlterColumn("dbo.LlamadaSolicitadas", "UsuarioTelef", c => c.String(nullable: true));
        }
    }
}
